#ifndef IDEMO_H_
#define IDEMO_H_

/**
	File: IDemo.h: 
	Desc: Our Demo Interface. Use this for creating new demos.
	Last Modified: 11/17/2013
	Author: LunarOwl
*/

#include <string>

using std::string;
class IDemo
{
public:
	IDemo(string name) : m_demoName(name) {}

	virtual ~IDemo() {}
	virtual void setup() = 0;
	virtual void run() = 0;
	virtual void cleanup() = 0;
	virtual void keyboard() = 0;
	virtual void mouse() = 0;

public:
	string m_demoName;
};

#endif