#ifndef BINARYTREE_H_
#define BINARYTREE_H_

struct BTNode
{
	BTNode(int value){
		left = NULL;
		right = NULL;
		this->value = value;
	};

	int value;
	BTNode* left;
	BTNode* right;
};

int  LookUpBT(BTNode* node, int value);
void InsertBT(BTNode*& tree, int value);
void DestroyBT(BTNode* node);
void PrintBT(BTNode* node, int indent);
int  FindMaxHeight(BTNode* node, int depth);
BTNode* MakeTreeFromArray();
BTNode* DeleteBT(BTNode* node, int value);

// Traversals
void PostOrderTraverse(BTNode* node);

#endif