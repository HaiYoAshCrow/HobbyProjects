#include "stdafx.h"
#include "SingleLinkedList.h"
#include "BinaryTree.h"
#include <vld.h>

void LinkedListTestCases();
void BinaryTreeTestCases();

int main()
{
	//LinkedListTestCases();
	BinaryTreeTestCases();

	system("pause");
    return 0;
}

void LinkedListTestCases()
{
	// Build the linked list
	SSLNode *head = new SSLNode(1);
	SSLNode *current = Insert(head,head, 2);
	SSLNode *previous;

	current = Insert(head,current, 3);
	current = Insert(head,current, 4);
	current = Insert(head,current, 5);
	previous = current;
	current = Insert(head,current, 1);
	current = Insert(head,current, 6);
	current = Insert(head,current, 3);

	cout << "\nOriginal:\n-------------" << endl;
	PrintList(head);

	// Middle insertion test case
	previous = Insert(head,previous, 7);
	previous = Insert(head,previous, 8);
	cout << "\nMiddle Insertion:\n-------------" << endl;
	PrintList(head);

	// Update head test case
	SSLNode* new_node = new SSLNode(17);
	head = UpdateHead(head, new_node);
	cout << "\nUpdating the head:\n-------------" << endl;
	PrintList(head);

	// Remove head test case
	head = UpdateHead(head, NULL);
	cout << "\nRemoving the head:\n-------------" << endl;
	PrintList(head);

	// Deleting replicants test case
	head = DeleteRepliants(head);
	cout << "\nDeleting replicants:\n-------------" << endl;
	PrintList(head);

	// Deleting general test case
	cout << "\nDeleting general:\n-------------" << endl;
	head = DeleteNode(head, 8);
	PrintList(head);

	// Make circular test case
	cout << "\nConverting into Circular Linked List:\n-------------" << endl;
	current = MakeCircular(head, GetLast(head));
	if (isCircular(head)) cout << "Linked List is circular\n" << endl; 
	else cout << "Linked List is not circular" << endl;

	// Circular print test case
	cout << "\nCircular print test:\n-------------" << endl;
	PrintList(head);
	
	// Deletion of a circular linked list end test case
	cout << "\nDeleting Circular Link List:\n-------------" << endl;
	head = DeleteNode(head, 9);
	PrintList(head);

	// Insertion into circular at the last element before loop
	cout << "\Inserting into Circular Link List:\n-------------" << endl;
	current = Insert(head, GetLast(head), 120);
	PrintList(head);

	// Clean up the linked list
	CleanUpLinkedList(head);
}

void BinaryTreeTestCases()
{
	BTNode* tree = NULL;
	InsertBT(tree, 5);
	InsertBT(tree, 3);
	InsertBT(tree, 7);
	InsertBT(tree, 4);
	InsertBT(tree, 2);
	InsertBT(tree, 1);
	InsertBT(tree, 12);
	InsertBT(tree, 8);
	InsertBT(tree, 10);
	InsertBT(tree, 15);

	//int max_depth = FindMaxHeight(tree, 0);

	//PrintBT(tree,0);

	DestroyBT(tree);
}
