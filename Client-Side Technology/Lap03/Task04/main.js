var num1 = Number(prompt("Enter Number 1"));
var num2 = Number(prompt("Enter Number 2"));
var num3 = Number(prompt("Enter Number 3"));

if (num1 % num2 == 0 && num1 % num3 == 0)
{
    console.log(`${num1} is divisible by both ${num2} and ${num3}`);
} else if (num1 % num2 == 0)
{
    console.log(`${num1} is divisible by ${num2} only`);
} else if (num1 % num3 == 0)
{
    console.log(`${num1} is divisible by ${num3} only`);
} else
{
    console.log(`${num1} not divisible`);
}