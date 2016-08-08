#include "stdafx.h"
#include "BinaryTree.h"
#include <string>
#include <iostream>
#include <iomanip> 
#include <algorithm>
#include <stack>

using namespace std;


/**
	Inserts a new leaf into the Binary Tree
	Notes:
	-	In order to actually update the tree pointer, we need to get either a 
		pointer to the tree's pointer, or a reference to the pointer of the tree.
		More Details: http://www.codeproject.com/Articles/4894/Pointer-to-Pointer-and-Reference-to-Pointer

	@param: tree node(reference to the pointer)
	@return: Nil

*/
void InsertBT(BTNode*& node, int value)
{
	if (node == NULL) // Tree is empty, make this the root node
	{
		node =  new BTNode(value);
	}
	else if(node->value >= value) // Insert left, value is smaller or equal to current node
	{
		// If left isn't NULL, keep travelling until we find an empty spot using recursion
		if (node->left != NULL)
		{
			InsertBT(node->left,value);
		}
		else
		{
			node->left = new BTNode(value);
		}
	}
	else if (node->value < value) // Insert right, value is larger than current node
	{
		// Do the same for the right
		if (node->right != NULL)
		{
			InsertBT(node->right, value);
		}
		else
		{
			node->right = new BTNode(value);
		}
	}
}


/**
	Deletes a Binary Tree systematically.

	@param: tree node(reference to the pointer)
	@return: Nil
*/
void DestroyBT(BTNode* node)
{
	if (node != NULL)
	{
		// Note:
		// We use recursion here to delete the lowest node, working our way
		// to the top most. The recursive function calls will do nothing if
		// these nodes are null, and will return to the first instance call
		// of the function. From there, if left and right are null, we simply
		// delete the parent node of the two child nodes.
		DestroyBT(node->left); 
		DestroyBT(node->right);
		delete node;
		node = NULL;
	}
}

/**
	Uses Post-order traversal in order to find the maximum depth of a tree

	@param: tree node(reference to the pointer)
	@return: Nil
*/
int FindMaxHeight(BTNode* node, int depth)
{
	int left_depth = depth, right_depth = depth;

	if (node->left != NULL)
	{
		FindMaxHeight(node->left, depth + 1);
	}

	if (node->right != NULL)
	{
		FindMaxHeight(node->right, depth + 1);
	}

	return left_depth > right_depth ? left_depth : right_depth;
}

void PostOrderTraverse(BTNode* node)
{
	if (node == NULL)
	{
		return;
	}

	// Initialise, add the first element to the tracker
	stack<BTNode*> tracker;
	tracker.push(node);
	BTNode* prev = NULL;

	
	while (!tracker.empty())
	{
		BTNode* curr = tracker.top();
		// Go down the tree
		if (prev == NULL || prev->left == curr || prev->right == curr)
		{

		}
	}


}

void PrintBT(BTNode* node, int indent)
{
	if (node != NULL)
	{
		
	}
}