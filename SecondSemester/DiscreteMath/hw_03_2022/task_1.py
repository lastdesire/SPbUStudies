#Задача 1. Указать какие из кодов для букв алфавита {a, b, c, d} являются префиксными. 
# • {1, 10, 0, 01} • {00, 010, 011, 01} • {10, 010, 011, 11} • {1, 00, 010, 011}
# Ответ: третий и четвертый.
print("Программа дает ответ, является ли код для букв алфавита префиксным. Введите буквы (строки, состоящие из 0 и 1), а когда закончите, введите -1.")
alphabetSet = set()
code = str(input())
while(code != "-1"):
    alphabetSet.add(code)
    code = str(input())
isPrefixCode = 1
alphabet = []
for i in alphabetSet:
    alphabet.append(i)
for i in range(0, len(alphabet)):
    for j in range(i + 1, len(alphabet)):
        if (alphabet[i].startswith(alphabet[j])):
            isPrefixCode = 0
            break
        if (alphabet[j].startswith(alphabet[i])):
            isPrefixCode = 0
            break
    if (isPrefixCode == 0):
        break
print(alphabet)
if (isPrefixCode == 1):
    print("Код является префиксным")
if (isPrefixCode == 0):
    print("Код не является префиксным")

