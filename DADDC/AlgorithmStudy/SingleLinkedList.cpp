#include "stdafx.h"
#include "SingleLinkedList.h"
#include <Windows.h>
#include <Mmsystem.h>

/**
	Implementaton of SingleLinkedList.h functions.

	@Author: Tuan
	@Last Modified: 26th April 2016
*/

/**
	Gets the last node of the list.

	@param: head node
	@return: last node
*/
SSLNode* GetLast(SSLNode* head)
{
	SSLNode* iterator = head;
	while (iterator->next != NULL)
	{
		if (iterator->next == head)
		{
			break;
		}
		iterator = iterator->next;
	}
	return iterator;
}

/**
	Inserts a node with a new value into the linked list.

	NOTE:
	This only considers  nodes that are in between head and end,
	not before. For removing the head, see the function UpdateHead().

	@param: head node (pointer), current node (pointer), value
	@return: current node (updated pointer)
*/
SSLNode* Insert(SSLNode* head, SSLNode* curr, int value)
{
	SSLNode* n = new SSLNode(value);

	// Last case insertion
	if (curr->next == NULL)
	{
		curr->next = n;
		n->next = NULL;
	}
	else if (curr == head) // Circular linked list condition
	{
		n->next = head;
		curr->next = n;
	}
	else // We have something in between
	{
		SSLNode* aux = curr->next;
		curr->next = n;
		curr->next->next = aux;
	}
	return n;
}

/**
	Deletes a node given a location

	@parm: Head node, location
	@return: Head node (Updated)
*/
SSLNode* DeleteNode(SSLNode* head, int location)
{
	if (head->next == NULL)
	{
		cout << "Nothing to delete! This list only has one element! Call CleanUpLinkedList() instead!" << endl;
		return head;
	}

	if (location < 0)
	{
		cout << "Invalid location! Please enter an integer between 0-n!" << endl;
		return head;
	}

	// A location of 0 gives us the head therefore, call the update function
	if (location == 0)
	{
		head = UpdateHead(head, NULL);
		return head;
	}

	// Keep track of the previous and the runner
	SSLNode* previous = head;
	SSLNode* runner = head;
	SSLNode* tmp;

	int counter = 0;

	while (runner != NULL && runner->next != NULL)
	{
		counter++;
		previous = runner;
		runner = runner->next;

		if (counter == location)
		{
			// Is this a circular linked list?
			if (runner->next == head)
			{
				delete runner;
				runner = NULL;
				previous->next = head;

				return head;
			}
			else // Normal deletion case
			{
				tmp = runner->next;
				delete runner;
				runner = NULL;
				previous->next = tmp;

				return head;
			}
		}
		else if (runner == head) // We've come full circle, abort!
		{
			cout << "Node listing [" << location << "] does not exist! You've looped the roundabout!" << endl;
			cout << "Oh? You thought this would be a normal error message? TOO BAD! I, DIO, HAVE TAKEN THE PLACE OF YOUR PROCESSES!" << endl;
			cout << "<== TO BE CONTINUED |\\|" << endl;

			PlaySound(L"wryyy.wav", 0, SND_FILENAME | SND_ASYNC );
			system("pause");
			return head;
		}
	}// Nothing found!
	cout << "Node listing [" << location << "] does not exist!" << endl;
	return head;
}

/**
	Deletes the first node that contains the value.
	
	@parm: Head node, value
	@return: Head node (Updated)
*/
SSLNode* DeleteFirstValue(SSLNode* head, int value)
{
	// There's only one element
	if (head->next == 0)
	{
		cout << "Nothing to delete! This list only has one element! Call CleanUpLinkedList() instead!" << endl;
		return head;
	}

	// If we delete the head, make the next node the head
	if (head->value == value)
	{
		head = UpdateHead(head, NULL);
	}

	SSLNode* aux = NULL;
	SSLNode* runner = head;

	while (runner->next != NULL)
	{
		if (runner->next->value == value)
		{
			aux = runner->next->next;
			delete runner->next;
			runner->next = aux;
			return head;
		}
		runner = runner->next;
	}
	return head;
}

/**
	Deletes all replicates from a linked list

	@parm: Heade node
	@return: Head node (Updated)
*/
SSLNode* DeleteRepliants(SSLNode* head)
{
	// Gotta keep track of 3 things, the node we're comparing (stayer), the node we're running with (runner)
	// and the node that's previous to the running node so we can re-link the list (previous).
	SSLNode* runner;
	SSLNode* stayer = head;
	SSLNode* previous;

	while (stayer->next != NULL)
	{
		runner = stayer->next;
		previous = stayer;

		while (runner != NULL)
		{
			if (runner->value == stayer->value)
			{
				previous->next = runner->next;
				delete runner;
				runner = previous->next;
			}
			else
			{
				previous = runner;
				runner = runner->next;
			}
		}
		stayer = stayer->next;
	}

	return head;
}

/**
	Update the head of the list. If new_node is NULL, we're deleting the head.

	@parm: Head nodef
	@return: Nil
*/
SSLNode* UpdateHead(SSLNode* head, SSLNode* new_node)
{
	// We're deleting the head
	if (new_node == NULL)
	{
		new_node = head->next;
		delete head;
		return new_node;
	}
	else
	{
		SSLNode* tmp = head;
		head = new_node;
		head->next = tmp;
		return head;
	}
}

/**
	Makes the linked list circular by referencing the header.

	@parm: Head node
	@return: current node (updated reference)
*/
SSLNode* MakeCircular(SSLNode* head, SSLNode* curr)
{
	if (head->next == NULL)
	{
		cout << "This list is empty! You need to add more elements!" << endl;
		return head;
	}

	curr->next = head;
	return head;
}

/**
	Unchain the linked list

	@parm: Head node
	@return: Head node
*/
SSLNode* MakeNonCircular(SSLNode* head)
{
	GetLast(head)->next = NULL;
	return head;
}

/**
	Determines if the linked list is circular. A circular linked list
	is defined by it's tail referencing it's head.

	@parm: Head node
	@return: true/false
*/
bool isCircular(SSLNode* head)
{
	if (head->next == NULL)
	{
		cout << "This list is empty! You need to add more elements!" << endl;
		return head;
	}

	SSLNode* stayer = head;
	SSLNode* runner = stayer;

	while (runner != NULL && runner->next != NULL)
	{
		runner = runner->next;
		if (runner == stayer)
		{
			return true;
		}
	}
	return false;
}

/**
	Debug function for displaying the contents of a linked list

	@parm: Head node
	@return: Nil
*/
void PrintList(SSLNode *head)
{
	if (head->next == NULL)
	{
		cout << "This list is empty! You need to add more elements!" << endl;
		return;
	}

	SSLNode *runner = head;
	int i = 0;
	while (runner != 0)
	{
		cout << "The value for node [" << i << "] is: " << runner->value << endl;
		runner = runner->next;
		i++;

		if (runner == head)
		{
			cout << "This list is a circular linked list, next element is head!" << endl;
			break;
		}
	}
}

/**
	Debug function for displaying the contents of a linked list

	@parm: Head node
	@return: Nil
*/
void CleanUpLinkedList(SSLNode* head)
{
	SSLNode* runner = head;
	int i = 0;
	while (runner->next != NULL)
	{
		SSLNode* tmp = runner->next;
		
		// In case this is a circular linked list, if the last element points to the location of the head
		// then we need to remove it.
		if (tmp == head)
		{
			break;
		}

		delete runner;
		runner = tmp;
	}
	head = NULL;
}
