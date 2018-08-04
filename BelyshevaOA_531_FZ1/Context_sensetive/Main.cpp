#include <algorithm>
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <set>
#include <map>

using namespace std;

set<string> set_terminal, set_not_terminal;
string pathSave;
map<int, string> pathFiles;

struct grammar
{
	int countProduction = 0;
	set<string> grammar_set_terminal, grammar_set_not_terminal;
	map<string, vector<string>> production;
	string start;
	string nameFile;
	map<string, string> correspondenceTable; // это когда изменяем??????????
};

void Merge(grammar grammar1, grammar grammar2)
{
	std::ofstream out;
	out.open(pathSave + "Merge.txt");

	string newStart = "S^^";
	while (set_not_terminal.find(newStart) != set_not_terminal.end())
	{
		newStart += "^";
	}
	set_not_terminal.insert(newStart);

	out << set_not_terminal.size() << endl;

	for (auto symbol : set_not_terminal)
	{
		out << symbol << endl;
	}

	out << set_terminal.size() << endl;

	for (auto symbol : set_terminal)
	{
		out << symbol << endl;
	}

	//построим p1'


	//вывод всех продукций + 2 продукции вида S'' -> S|S'
	/*out << grammar1.countProduction + grammar2.countProduction + 2 << endl;
	out << beginSimbolGrammar << ' ' << grammar1.beginSimbol << endl;
	out << beginSimbolGrammar << ' ' << grammar2.beginSimbol << endl;
	for (auto i = grammar1.production.begin(); i != grammar1.production.end(); i++)
	{
		for (auto j = i->second.begin(); j != i->second.end(); j++)
		{
			out << i->first << ' ' << *j << endl;
		}
	}
	for (auto i = grammar2.production.begin(); i != grammar2.production.end(); i++)
	{
		for (auto j = i->second.begin(); j != i->second.end(); j++)
		{
			out << i->first << ' ' << *j << endl;
		}
	}

	out << beginSimbolGrammar << endl;*/

	out.close();
}

int main(int idx)
{
	pathSave = "C:\\Users\\oksbe\\source\\repos\\BelyshevaOA_531_FZ1";
	pathFiles.insert(pair<int, string>(1,pathSave+"1.txt"));
	pathFiles.insert(pair<int, string>(2, pathSave + "2.txt"));

	setlocale(LC_ALL, "rus");

	grammar grammar1, grammar2;
	bool flag1 = ReadFile(grammar1, 1);
	bool flag2 = ReadFile(grammar2, 2);

	if (!flag1 || !flag2) return -1;

	switch (idx)
	{
	case 1:
	{
		Merge(grammar1, grammar2);
		break;
	}
	case 2:
	{
		//Concatenation(grammar1, grammar2);
		break;
	}
	case 3:
	{
		//Iteration(grammar1);
		break;
	}
	case 4:
	{
		//MirrorImage(grammar1);
		break;
	}
	default:
		cout << "Неверны входные данные" << endl;
		break;
	}
	return 0;
}

bool ReadFile(grammar & grammarForRead, int idx)
{
	if (!pathFiles.count(idx)) return false;
	grammarForRead.nameFile = pathFiles[idx];


	ifstream fileIn(grammarForRead.nameFile);

	int n;
	fileIn >> n;

	for (int i = 0; i < n; i++)
	{
		string symbol;
		fileIn >> symbol;
		grammarForRead.grammar_set_not_terminal.insert(symbol);
	}

	fileIn >> n;

	for (int i = 0; i < n; i++)
	{
		string symbol;
		fileIn >> symbol;
		grammarForRead.grammar_set_terminal.insert(symbol);
	}

	fileIn >> n;

	grammarForRead.countProduction = n;

	for (int i = 0; i < n; i++)
	{
		string a, b;
		fileIn >> a >> b;
		grammarForRead.production[a].push_back(b);
	}

	fileIn >> grammarForRead.start;
	if (!set_not_terminal.empty())
	{
		string temp = grammarForRead.start;
		while (set_not_terminal.find(grammarForRead.start) != set_not_terminal.end())
		{
			grammarForRead.start += "^";
		}
		grammarForRead.grammar_set_not_terminal.erase(temp);
		grammarForRead.grammar_set_not_terminal.insert(grammarForRead.start);
		grammarForRead.correspondenceTable[temp] = grammarForRead.start;
	}

	set_not_terminal.insert(grammarForRead.grammar_set_not_terminal.begin(), grammarForRead.grammar_set_not_terminal.end());
	set_terminal.insert(grammarForRead.grammar_set_terminal.begin(), grammarForRead.grammar_set_terminal.end());

	fileIn.close();
	return true;
}