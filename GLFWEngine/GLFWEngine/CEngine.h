#ifndef CENGINE_H_
#define CENGINE_H_

/**
	File: CEngine.h 
	Desc: Our engine class
	Last Modified: 11/17/2013
	Author: LunarOwl
*/
#include <Windows.h>
#include <iostream>
#include <string>
#include "IDemo.h"

#include <glew.h>
#include <GLFW\glfw3.h>

using std::string;

class CEngine
{
public:
	CEngine(unsigned int window_width, unsigned int window_height, unsigned int glMajorVersion,
			unsigned int glMinorVersion, char* windowTitle);
	~CEngine();

	void setup(bool fullScreenEnable);
	void attachDemo(IDemo* demoInstance);
	void run();
	void cleanup();

private:
	static void window_size_callback(GLFWwindow* window, int width, int height);
	void keyboard();
	void mouse();

private:
   bool m_isFullScreen;
   static int m_windowWidth;
   static int m_windowHeight;
   unsigned int m_glMinorVersion;
   unsigned int m_glMajorVersion;
 
   string m_windowTitle;
   IDemo* m_demoInstance;
   GLFWwindow* m_window;
};

#endif