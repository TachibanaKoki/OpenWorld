#ifndef _CSVIO_H
#define _CSVIO_H
#include <fstream>
#include <string>
#include <sstream>
#include <vector>

using namespace std;

class CSVIO
{
public:
	CSVIO();
	~CSVIO();
	void ReadCSV(string& filePath);
private:
	vector<string> Split (string& input, char delimiter);
};
#endif // !CSVIO_H
