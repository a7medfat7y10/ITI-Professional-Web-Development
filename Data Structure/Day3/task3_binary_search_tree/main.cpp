#include <iostream>

using namespace std;

struct Node
{
    int key; //Data
    Node* Pleft;
    Node* Pright;
};

//point to the first node(Pstart or Proot)
Node* Ptree = NULL;

//to search
Node* SearchBinaryTree(Node* Proot, int key)
{
    if (Proot != NULL)
    {
        if (Proot->key ==  key)
            return Proot;
        else if (Proot->key > key)
            return SearchBinaryTree(Proot->Pleft, key);
        else
            return SearchBinaryTree(Proot->Pright, key);
    }
    return NULL;//empty tree
}

//to count elements
int CountNodes(Node* Proot)
{
    if(Proot != NULL)
    {
        return CountNodes(Proot->Pleft) + 1 + CountNodes(Proot->Pright);
    }
    return 0;
}

//to print the values in order
void TreeTraverse(Node* Proot)
{
    if(Proot != NULL)
    {
        TreeTraverse(Proot->Pleft);

        cout << Proot->key << endl ;

        TreeTraverse(Proot->Pright);
    }
}


///To Get Height
int height(Node * r)
{
    if (r == NULL)
        return -1;
    else
    {
        /* compute the height of each subtree */
        int lheight = height(r -> Pleft);
        int rheight = height(r -> Pright);

        /* use the larger one */
        if (lheight > rheight)
            return (lheight + 1);
        else
            return (rheight + 1);
    }
}

///To Get Balance factor of node n
int getBalanceFactor(Node* n)
{
    if (n == NULL)
        return -1;
    return height(n -> Pleft) - height(n -> Pright);
}

///right rotate of node n
Node * rightRotate(Node* n)
{
    //the left child of the node ->x
    Node * x = n -> Pleft;
    //the right child of the left child -> y
    Node * y = x -> Pright;

    // Perform rotation
    x -> Pright = n;
    n -> Pleft = y;

    //now the left child is the root
    return x;
}

///left rotate of node n
Node * leftRotate(Node* n)
{
    //the right child of the node n
    Node * x = n->Pright;
    //the left child of the right child
    Node * y = x->Pleft;

    // Perform rotation
    x -> Pleft = n;
    n -> Pright = y;

    //now the right child is the root
    return x;
}

//create new node
Node* NewNode()
{
    Node* Pnew = new Node();
    if (Pnew == NULL)
    {
        exit(0);
    }
    Pnew->Pleft = Pnew->Pright = NULL;

    //input data
    int x;
    do
    {
        cout << "Enter new key(Please No duplicates): ";
        cin >> x;
        if(SearchBinaryTree(Ptree, x) != NULL)
        {
            cout << "This key already exists \n";
        }
    } while(SearchBinaryTree(Ptree, x) != NULL);

    Pnew->key = x;

    return Pnew;
}


//insert version one: passing pointer by reference
Node* InsertNode(Node* &Proot, Node* Pnew)
{
    //if empty list then this new node will be the root
    if (Proot == NULL)
    {
        Proot = Pnew;
        cout << "key inserted successfully" << endl;
        return Proot;
    }

    else if (Proot->key > Pnew->key)
    {
        Proot -> Pleft = InsertNode(Proot -> Pleft, Pnew);
    }
    else if (Pnew -> key > Proot -> key) {
        Proot -> Pright = InsertNode(Proot -> Pright, Pnew);
    }


    ///Maintain Balanced
    int bf = getBalanceFactor(Proot);
    // left left Case
    if (bf > 1 && Pnew -> key < Proot -> Pleft -> key)
      return rightRotate(Proot);

    // right right Case
    if (bf < -1 && Pnew -> key > Proot -> Pright -> key)
      return leftRotate(Proot);

    // left right Case
    if (bf > 1 && Pnew -> key > Proot -> Pleft -> key) {
      Proot -> Pleft = leftRotate(Proot -> Pleft);
      return rightRotate(Proot);
    }

    // right left Case
    if (bf < -1 && Pnew -> key < Proot -> Pright -> key) {
      Proot -> Pright = rightRotate(Proot -> Pright);
      return leftRotate(Proot);
    }

    /* return the (unchanged) node pointer */
    return Proot;
}


//insert version two: using two pointers root and leaf
/*
void InsertNodeV2(Node* Proot, Node* Pleaf, Node* Pnew)
{
    if (Pleaf == NULL)
    {
        //empty tree
        if (Proot == NULL)
            Ptree = Pnew;
        else
        {
            if (Proot-> key > Pnew-> key)
                Proot->Pleft = Pnew;
            else
                Proot->Pright = Pnew;
        }
    }
    else if (Pnew->key < Pleaf->key)
        InsertNodeV2(Pleaf, Pleaf->Pleft, Pnew);
    else
        InsertNodeV2(Pleaf, Pleaf->Pright, Pnew);
}
*/

void DeleteNode(Node* &Proot);
int GetMax(Node* Proot);

//to detect which element to delete
void Delete (Node* &Proot, int key)
{
    if (key < Proot->key)
        Delete(Proot->Pleft, key);
    else if (key>Proot->key)
        Delete(Proot->Pright, key);
    //if key == proot->key => element found
    else
        DeleteNode(Proot);
}

//to delete the node from the tree
void DeleteNode(Node* &Proot)
{
    Node* Pdelete = Proot;
    //if leaf or node with single child
    //if no child in left
    if(Proot->Pleft == NULL)
    {
        Proot = Proot->Pright;
        delete Pdelete;
    }
    //if no child in right
    else if(Proot->Pright == NULL)
    {
        Proot = Proot->Pleft;
        delete Pdelete;
    }
    //if the node has two child
    //we need to search for the most right node on the left subtree or
    //the most left node on the right subtree
    // then swap this node with the node we need to delete and delete its
    else
    {
        //get the data in the most right node then put it in the node i want to delete
        int temp_key = GetMax(Proot->Pleft);
        Proot->key = temp_key;
        Delete(Proot->Pleft, temp_key );
    }


    ///to maintain balanced
    int bf = getBalanceFactor(Proot);
    // left left Imbalance/Case or right rotation
    if (bf == 2 && getBalanceFactor(Proot -> Pleft) >= 0)
      rightRotate(Proot);
    // left right Imbalance/Case or LR rotation
    else if (bf == 2 && getBalanceFactor(Proot -> Pleft) == -1) {
      Proot -> Pleft = leftRotate(Proot -> Pleft);
        rightRotate(Proot);
    }
    // right right Imbalance/Case or left rotation
    else if (bf == -2 && getBalanceFactor(Proot -> Pright) <= -0)
       leftRotate(Proot);
    // right left Imbalance/Case or RL rotation
    else if (bf == -2 && getBalanceFactor(Proot -> Pright) == 1) {
      Proot -> Pright = rightRotate(Proot -> Pright);
       leftRotate(Proot);
    }
}

//to get the most right node on the left sub tree (highest value in left)
int GetMax(Node* Proot)
{
    while (Proot->Pright != NULL)
        //traverse to the most right
        Proot = Proot->Pright;

    return Proot->key;
}

int main()
{
    //insert node
    for(int i=0; i<6; i++)
        Ptree = InsertNode(Ptree, NewNode());
        //InsertNodeV2(Ptree,Ptree, NewNode());

    cout << "The Balance Factor" <<  getBalanceFactor(Ptree)<<endl;
    //delete node
    Delete(Ptree, 5);

    cout << "The Balance Factor after deletion" <<  getBalanceFactor(Ptree)<<endl;

    //display tree
    cout << "The tree values are:" <<endl;
    TreeTraverse(Ptree);


    //count nodes
    cout << "Nodes Count:" << CountNodes(Ptree) << endl;

    //search nodes
    Node* Psearch = SearchBinaryTree(Ptree, 10);
    if(Psearch != NULL)
    {
        cout << "Found\n";
    }
    else
    {
        cout << "Not found\n";
    }

    return 0;
}
