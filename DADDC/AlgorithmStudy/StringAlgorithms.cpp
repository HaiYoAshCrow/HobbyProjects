#include "stdafx.h"
#include "StringAlgorithms.h"

/**
	Implementaton of StringAlgorithm.h functions.

	@Author: Tuan
	@Last Modified: 26th April 2016
*/

/**
	Naive implementation of the remove duplicate string algorithm.
	Unique characters are preserved, but white spaces will
	seperate them.

	Run-time complexity: O(n^2)

	@params: string
	@returns: null
*/
void RemoveReplicantNaive(string str)
{
	for (int i = 0; i <= size(str); i++)
	{
		for (int j = i + 1; j <= size(str); j++)
		{
			if (str[i] == str[j])
			{
				str[j] = 0;
				if (DEBUG_FLAG)
				{
					cout << "Found a match!\n";
					cout << str << endl;
				}
			}
		}
	}

	cout << "Naive result is: " << str << endl;
}

/**
	Implementation of the remove duplicate string algorithm but with sorting.
	Unique characters will end up at the start and are seperated by
	a null terminator. Reading/parsing becomes easier.

	Run-time complexity: O(n^2)

	@params: string
	@returns: null
*/
void RemoveReplicantTail(string str)
{
	int tail = 1;
	for (int i = 1; i < size(str); i++)
	{
		int j;
		for (j = 0; j < tail; j++)
		{
			if (str[i] == str[j])
			{
				break;
			}
		}
		if (j == tail)
		{
			str[tail] = str[i];
			tail++;
		}
	}

	// Null terminator for C-style
	str[tail] = 0;

	cout << "Sorted Result is: " << str << endl;
}

/**
	Determines whether two strings are anagrams or not. Whitespaces and capital
	letters have been taken into consideration of. 

	Run-time complexity: O(n) constant

	@params: string
	@returns: null
*/
void IsAnagram(string str1, string str2)
{
	// Strip all white space from the strings since we *can* have anagrams like
	// [Tomato -> To Atom] or [Cellery -> Cell Rye]. 
	str1.erase(remove_if(str1.begin(), str1.end(), isspace), str1.end());
	str2.erase(remove_if(str2.begin(), str2.end(), isspace), str2.end());

	// Check whether the two strings are still the same size. It's arguable
	// that perhaps replacing this with a white-space comparator would improve
	// processing efficiency. Might be worth exploring.
	if (str1.length() == str2.length())
	{
		// Each character corresponds to a hexadecimal value. Through the subtraction
		// of any arbitary character value, we'll obtain a difference result.
		// If two strings are anagrams, these differences should add up to the
		// same sum.
		int str1_sum = 0;
		int str2_sum = 0;

		for (int i = 0; i <= str1.length(); i++)
		{
			// Make sure we have a common basis for comparison, capitals and lowercase
			// have different hex values.
			str1_sum += tolower(str1[i]) - 'a';
			str2_sum += tolower(str2[i]) - 'a';
		}

		if (str1_sum == str2_sum)
		{
			cout << "Strings are an anagram: Same size, same characters!" << endl;
		}
		else
		{
			cout << "Strings are not an anagram: Different characters!" << endl;
		}
	}
	else
	{
		cout << "Strings are not an anagram: Not the same size!" << endl;
	}
}

void ReverseString()
{

}
