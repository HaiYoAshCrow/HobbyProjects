/**
	File: main.cpp
	Desc: Main Entry point
	Last Modified: 11/17/2013
	Author: LunarOwl
*/

#include "CEngine.h"
#include "ExampleDemo.h"
void main()
{
	CEngine* engine = new CEngine(800,600,3,2,"Demo Engine");
	ExampleDemo* demo = new ExampleDemo("Example Demo");

	engine->attachDemo(demo);
	engine->setup(false);
	engine->run();

	delete demo;
	demo = NULL;

	delete engine;
	engine = NULL;
}