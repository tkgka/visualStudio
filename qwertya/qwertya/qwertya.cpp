#include <iostream>
#include <vector>
using namespace std;

int main() {
	int r;
	cin >> r;
	if (r > 4) {
		r = r % 4;
	}
	printf("%d", r);
}