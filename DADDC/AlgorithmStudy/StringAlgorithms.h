#pragma once
#ifndef REVERSESTRING_H_
#define REVERSESTRING_H_

#include <string>
#include <iostream>
#include <algorithm>

using namespace std;

#define DEBUG_FLAG 0

/**
	Implementaton of various string manipulation algorithms.

	@Author: Tuan
	@Last Modified: 26th April 2016
*/

void RemoveReplicantNaive(string str);
void RemoveReplicantTail(string str);
void IsAnagram(string str1, string str2);
void ReverseString();

#endif