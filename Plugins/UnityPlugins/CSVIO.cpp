#include "CSVIO.h"

//�R���X�g���N�^
CSVIO::CSVIO()
{
}
	
//�f�X�g���N�^
CSVIO::~CSVIO()
{
}

void ReadCSV()
{

}

vector<string> Split(string& input, char delimiter)
{
	istringstream stream(input);
	string field;
	vector<string> result;
	while (getline(stream, field, delimiter)) {
		result.push_back(field);
	}
	return result;
}


