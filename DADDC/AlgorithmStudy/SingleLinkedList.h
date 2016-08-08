#ifndef LINKEDLIST_H_
#define LINKEDLIST_H_
#pragma once
#include <iostream>
#include <string>
#include <cctype>
#include <algorithm>

using namespace std;

/**
	Implementaton of a Linked List Node used for construting linked lists. 
	Constructor accepts an int value. Insertion/Deletion is O(1), but search
	is O(n) constant.

	@Author: Tuan
	@Last Modified: 26th April 2016
*/
struct SSLNode
{
	SSLNode(int v)
	{
		value = v;
		next = NULL;
	}

	int value;
	SSLNode * next;
};

// Function prototypes
SSLNode* GetLast(SSLNode* head);
SSLNode* Insert(SSLNode* head, SSLNode* curr, int value);
SSLNode* DeleteFirstValue(SSLNode* head, int value);
SSLNode* DeleteNode(SSLNode* head, int location);
SSLNode* DeleteRepliants(SSLNode* head);
SSLNode* UpdateHead(SSLNode* head, SSLNode* new_node);
SSLNode* MakeCircular(SSLNode* head, SSLNode* curr);
SSLNode* MakeNonCircular(SSLNode* head);
bool isCircular(SSLNode* head);

void PrintList(SSLNode* head);
void CleanUpLinkedList(SSLNode* head);

#endif