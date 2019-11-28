// 2in1.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//
#include<iostream>
using namespace std;

int C[20];
int main() {
	int s, n, a, i, j, pos;
	cin >> s >> n;

	for (i = 1; i <= n; i++) {
		cin >> a;
		pos = -1;

		for (j = 0; j < s; j++) { if (C[j] == a) pos = j; }

		if (pos == -1) { //Cache Miss인 경우 - 한칸씩 밀기
			for (j = s - 1; j >= 1; j--) C[j] = C[j - 1];
		}
		else { //Cache Hit인 경우 - 원래 있던 자리 앞부터 한칸씩 밀기
			for (j = pos; j >= 1; j--) C[j] = C[j - 1];
		}

		C[j] = a;
	}
	for (i = 0; i < s; i++) { cout << C[i] << " "; }
	return 0;
}