/**
	File: simple.glsl.frag
	Desc: Simple fragment shader that outputs vertex colors
    Autho: LunarOwl
    Last Modified: 20/11/2013
*/

#version 330 core

in vec3 pass_color;
out vec3 out_color;

void main()
{
	out_color = pass_color;
}