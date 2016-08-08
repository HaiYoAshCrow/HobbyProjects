/**
	File: CEngine.cpp
	Desc: CEngine class definition
	Last Modified: 11/17/2013
	Author: LunarOwl
*/

#include "CEngine.h"

// Static decleration
int CEngine::m_windowWidth = 0;
int CEngine::m_windowHeight = 0;

/**
	Constructor

	@Params: window width, window height, glMinor version, glMajor version, window title
*/
CEngine::CEngine(unsigned int window_width, unsigned int window_height, unsigned int glMajorVersion,
			unsigned int glMinorVersion, char* windowTitle)
{

	m_windowWidth = window_width;
	m_windowHeight = window_height;
	m_glMinorVersion = glMinorVersion;
	m_glMajorVersion = glMajorVersion;
	m_windowTitle = windowTitle;
	m_demoInstance = NULL;
}

/**
	Destructor

	@Params: Nil
*/
CEngine::~CEngine()
{
}

/**
	Resizes window viewport

	@Params: window width, window height
	@Returns: Nil
*/
void CEngine::window_size_callback(GLFWwindow* window, int width, int height)
{
	glViewport(0, 0, width, height);
	m_windowWidth = width;
	m_windowHeight = height;

	printf("Window size is: %i x %i pixels\n",m_windowWidth,m_windowHeight);
}

/**
	Attach given demo to run

	@Params: Demo
	@Returns: Nil
*/
void CEngine::attachDemo(IDemo* demo)
{
	m_demoInstance = demo;
}

/**
	Setup the engine

	@Params: full screen?
	@Returns: Nil
*/
void CEngine::setup(bool fullScreenEnable)
{
	// Initialize glfw
	if(!glfwInit())
	{
		fprintf(stderr,"Error: Failed to initialize glfw.\n");
		system("pause");
		exit(EXIT_FAILURE);
	}

	glfwWindowHint(GLFW_SAMPLES, 64);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, m_glMajorVersion);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, m_glMinorVersion);
	glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

	m_window = glfwCreateWindow(m_windowWidth, m_windowHeight, m_windowTitle.c_str(), fullScreenEnable ? glfwGetPrimaryMonitor() : NULL, NULL);
	if(!m_window)
	{
		glfwTerminate();
		fprintf(stderr,"Error: Could not create window context.\n");
		system("pause");
		exit(EXIT_FAILURE);
	}

	glfwSetWindowSizeCallback(m_window, window_size_callback);
	glfwMakeContextCurrent(m_window);
	
	// Initialize GLEW
	glewExperimental = GL_TRUE; // Needed for core profile
	GLenum err = glewInit(); 
	if (err != GLEW_OK) 
	{
		fprintf(stderr, "Failed to initialize GLEW\n");
		fprintf(stderr, "Error: %s\n", glewGetErrorString(err));
		system("pause");
		exit(EXIT_FAILURE);
	}

	// Setup our attached demo if it exists
	if(m_demoInstance != NULL)
	{
		m_demoInstance->setup();
		printf("Demo Detected: %s\n", m_demoInstance->m_demoName.c_str());
	}
}

/**
	Runs the engine and associated demo(s)

	@Params: Nil
	@Returns: Nil

*/
void CEngine::run()
{
	while(!glfwWindowShouldClose(m_window))
	{

		int w, h;
		w = m_windowWidth;
		h = m_windowHeight;

		glfwGetFramebufferSize(m_window, &w, &h);

		/* Magic! */
		if(m_demoInstance != NULL){
			m_demoInstance->run();
		}
		
		mouse();
		keyboard();

		glfwSwapBuffers(m_window);
		glfwPollEvents();
	}
}

/**
	Handles keyboard events

	@Params: Nil
	@Returns: Nil

*/
void CEngine::keyboard()
{
	//Process the demo keyboard input if any
	if(m_demoInstance != NULL)
		m_demoInstance->keyboard();

	//If KeyPressed == ESC, stop the engine and exit
	if (glfwGetKey(m_window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
	{
		printf("Shutting down Engine\n");
		glfwSetWindowShouldClose(m_window,GL_TRUE);
		cleanup();
	}
}

/**
	Handles mouse events

	@Params: Nil
	@Returns: Nil

*/
void CEngine::mouse()
{
	if(m_demoInstance != NULL)
	{
		m_demoInstance->mouse();
	}
}

/**
	Cleans everything up

	@Params: Nil
	@Returns: Nil
*/
void CEngine::cleanup()
{
	if(m_demoInstance != NULL)
	{
		m_demoInstance->cleanup();
		m_demoInstance = NULL;
	}

	glfwDestroyWindow(m_window);
	glfwTerminate();

	exit(EXIT_SUCCESS);
}