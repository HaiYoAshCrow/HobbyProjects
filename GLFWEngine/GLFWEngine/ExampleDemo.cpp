/**
	File: ExampleDemo.cpp
	Desc: Definition of example demo class
	Last Modified: 18/11/2013
	Author: LunarOwl
*/

#include "ExampleDemo.h"

/**
	Constructor

	@Params: demo name
*/
ExampleDemo::ExampleDemo(string name) : IDemo(name)
{
}

/**
	Destructor

	@Params:Nil
*/
ExampleDemo::~ExampleDemo()
{
}

/**
	Setup the demo

	@Params: Nil
	@Returns: Nil
*/
void ExampleDemo::setup()
{
	glClearColor(0.6f,0.6f,1.0f,0.0f);

	// Triangle data
	GLfloat* vertices = new float[9];
	vertices[0] = -1.0; vertices[1] = -1.0;  vertices[2] = 0.0;
	vertices[3] = 1.0; vertices[4] = -1.0; vertices[5] = 0.0;
	vertices[6] = 0.0;  vertices[7] = 1.0;  vertices[8] = 0.0;

	// Color data
	GLfloat* colors = new float[9];
	colors[0] = 1.0f; colors[1] = 0.0f; colors[2] = 0.0f;
	colors[3] = 0.0f; colors[4] = 1.0f; colors[5] = 0.0f;
	colors[6] = 0.0f; colors[7] = 0.0f; colors[8] = 1.0f;

	// Generate the Vertex Array and buffer (Note: This code is for OpenGL 3.x+ !)
	glGenVertexArrays(1, &m_vertexArray);
	glBindVertexArray(m_vertexArray);

	// First the vertex buffer
	glGenBuffers(1, &m_vertexBuffer);
	glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
	glBufferData(GL_ARRAY_BUFFER, 9*sizeof(GLfloat), vertices, GL_STATIC_DRAW);
	glBindBuffer(GL_ARRAY_BUFFER,0);

	glBindVertexArray(0);

	// Now the color buffer
	glGenBuffers(1, &m_colorBuffer);
	glBindBuffer(GL_ARRAY_BUFFER, m_colorBuffer);
	glBufferData(GL_ARRAY_BUFFER, 9*sizeof(GLfloat), colors, GL_STATIC_DRAW);
	glBindBuffer(GL_ARRAY_BUFFER, 0);

	loadShaders("simple.glsl.vert", "simple.glsl.frag");
}

/**
	Run the demo

	@Params: Nil
	@Returns: Nil
*/
void ExampleDemo::run()
{
	glClear( GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT );
	glEnable(GL_DEPTH_TEST);

	// Bind the shader program and arrays for drawing
	glUseProgram(m_programID);
	glBindVertexArray(m_vertexArray);

	glEnableVertexAttribArray(0);
	glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, 0);

	glEnableVertexAttribArray(1);
	glBindBuffer(GL_ARRAY_BUFFER, m_colorBuffer);
	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 0, 0);

	glDrawArrays(GL_TRIANGLES,0,3);

	glDisableVertexAttribArray(1);
	glDisableVertexAttribArray(0);
	glBindVertexArray(0);

	glUseProgram(0);
}

/**
	Demo keyboard actions

	@Params: Nil
	@Returns: Nil
*/
void ExampleDemo::keyboard()
{
}

/**
	Demo mouse actions

	@Params: Nil
	@Returns: Nil
*/
void ExampleDemo::mouse()
{
}

/**
	Demo Cleanup

	@Params: Nil
	@Returns: Nil
*/
void ExampleDemo::cleanup()
{
	if(m_vertexShaderID != NULL)
	{
		glDetachShader(m_programID, m_vertexShaderID);
		glDeleteShader(m_vertexShaderID);
	}

	if(m_fragmentShaderID != NULL)
	{
		glDetachShader(m_programID, m_fragmentShaderID);
		glDeleteShader(m_fragmentShaderID);
	}

	if(m_programID != NULL)
	{
		glDeleteProgram(m_programID);
	}
}

/**
	Loads a very basic shader program consisting of a vertex shader and a fragment shader

	@Params:Vertex Shader, Fragment Shader
	@Returns: program ID
*/
void ExampleDemo::loadShaders(const char* vs_file, const char* fs_file)
{
	GLint compiled; // Compiled status

	m_vertexShaderID = glCreateShader(GL_VERTEX_SHADER);
	m_fragmentShaderID = glCreateShader(GL_FRAGMENT_SHADER);

	// Read in the vertex shader
	char* vs_src = readText(vs_file);
	const char* src = vs_src;
	if(vs_src != NULL)
	{
		glShaderSource(m_vertexShaderID, 1, &src, NULL);
		free(vs_src);

		glCompileShader(m_vertexShaderID);
		glGetShaderiv(m_vertexShaderID, GL_COMPILE_STATUS, &compiled);
		if(compiled == GL_FALSE)
		{
			printf("Failed to compile vertex shader. \n");
		}
	}
	else
	{
		printf("Unable to read source.\n");
	}

	// Now for the fragment shader
	char* fs_src = readText(fs_file);
	src = fs_src;
	if(fs_src != NULL)
	{
		glShaderSource(m_fragmentShaderID, 1, &src, NULL);
		free(fs_src);

		glCompileShader(m_fragmentShaderID);
		glGetShaderiv(m_fragmentShaderID, GL_COMPILE_STATUS, &compiled);
		if(compiled == GL_FALSE)
		{
			printf("Failed to compile fragment shader. \n");
		}
	}
	else
	{
		printf("Unable to read source.\n");
	}

	// Compile the program
	m_programID = glCreateProgram();

	glAttachShader(m_programID, m_vertexShaderID);
	glAttachShader(m_programID, m_fragmentShaderID);

	glLinkProgram(m_programID);
	
	GLint linked;

	glGetShaderiv(m_programID, GL_LINK_STATUS, &linked);
	if(linked == GL_FALSE)
	{
		printf("Unable to link program.\n");
	}
}

/**
	Read Text file and stores it into a character array. Aulixary function for loading shaders.

	@Params: File
	@Returns: text content
*/
char* ExampleDemo::readText(const char* file)
{
	FILE* fp;
	char* content = NULL;

	int count = 0;

	// Check if file exists
	if(file != NULL)
	{
		fopen_s(&fp,file,"rt");

		// If file exists
		if(fp != NULL)
		{
			fseek(fp, 0, SEEK_END);
			count = ftell(fp);
			rewind(fp);
		
			// Read to end of file if characters exist
			if(count > 0)
			{
				content = (char*)malloc(sizeof(char)* (count + 1));
				count = fread(content,sizeof(char),count,fp);
				content[count] = '\0';
			}
			else
			{
				fclose(fp);
				printf("File '%s' is Empty.\n", file);
				return NULL;
			}
			fclose(fp);
		}
		else
		{
			printf("No such file exists under %s.\n", file);
			return NULL;
		}
	}	

	return content;
}