#ifndef EXAMPLEDEMO_H_
#define EXAMPLEDEMO_H_

/**
    File: ExampleDemo.h
	Desc: Simple demo that draws a colored triangle
	Last Modified: 18/11/2013
	Author: LunarOwl
*/

#include <glew.h>
#include <GLFW\glfw3.h>
#include "IDemo.h"

class ExampleDemo : public IDemo
{
public:
	ExampleDemo(string name);
	virtual ~ExampleDemo();

	void setup();
	void run();
	void cleanup();
	void keyboard();
	void mouse();

private:
	void  loadShaders(const char* vs_file, const char* fs_file);
	char* readText(const char* file);

private:
	GLuint m_vertexArray;
	GLuint m_vertexBuffer;
	GLuint m_colorBuffer;

	GLuint m_vertexShaderID;
	GLuint m_fragmentShaderID;
	GLuint m_programID;
};

#endif