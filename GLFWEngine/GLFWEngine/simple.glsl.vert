/**
	File: simple.glsl.vert
	Desc: Simple vertex shader that outputs vertex colors and vertex position
    Autho: LunarOwl
    Last Modified: 20/11/2013
*/
#version 330 core

layout(location = 0) in vec3 vertexPosition_modelSpace;
layout(location = 1) in vec3 vertexColor_model;

out vec3 pass_color;

void main()
{
	// Cheap method of scaling
	gl_Position.xyz = vertexPosition_modelSpace * 0.4;
	gl_Position.w = 1.0;

	pass_color = vertexColor_model;
}