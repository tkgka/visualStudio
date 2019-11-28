#include <string>
#include <vector>
#include <iostream>
using namespace std;
	
int p[4] = { 2, 1, 3, 2 };
int l = 2;
int main() {
	int max = 0;

	for (int i = 0; i < 4; i++) {
		if (p[max] < p[i]) {
			max = i;
			for (int j = i; j < 4 + i; j++) {
				p[j] = p[j-i];
			}
		}
	}
}