#include <stdio.h>
#include <unistd.h>
int main()
{
	int pid1;
	int pid2;
	pid1=fork();
	if(pid1==0){
		printf("B");
	}
	else if(pid1>0){
		pid2=fork();
		if(pid2==0){
			printf("C");
		}
		else if(pid1==0){
			printf("B");
		}
		else{
			printf("A");
		}
	}
	return 0;
}
