#Задание 4.2.3 и 4.4
#Для сообщения “abcbbbbbacabbacddacdbbaccbbadadaddd abcccccbacabbacbbaddbdaccbbddadadcc bcabbcdabacbbacbbddcbbaccbbdbdadaac<EOF>”, приняв за алфавит {a,b,c,d,<space>,<EOF>}
#2) Построить код Шеннона-Фано для отдельных символов.
#3) Закодировать сообщение.
#Источник: https://www.cyberforum.ru/python-beginners/thread2813679.html

Code = []
a = open("input.txt")
textstr = a.read()
text = []
for i in range(len(textstr)):
    text.append(textstr[i])
text.append("<EOF>") #Добавляем <EOF>.

d = {}
for i in text:
    if i not in '!—,.-?...()—:;«»\nъь':
        d[i] = d.get(i, 0) + 1
sum_sim = sum(d.values())
for i in d:
    d[i] = round(d[i] / sum_sim, 3)
d = sorted(d.items(), key=lambda x: x[1], reverse=True)
arr = []
for i in d:
    arr.append(list(i) + [''])
 
 
def func(arr):
    half = sum(map(lambda x: x[1], arr))
    sum1 = 0
    for i, j in enumerate(arr):
        sum1 += j[1]
        if sum1 * 2 >= half:
            index = i + (abs(2 * sum1 - half) < abs(2 * (sum1 - j[1]) - half))
            break
 
    arr0, arr1 = [], []
    for i in arr[:index]:
        i[2] += '0'
        arr0.append(i)
    for i in arr[index:]:
        i[2] += '1'
        arr1.append(i)
 
    if len(arr1) == 1:
        Code.append(arr1)
    else:
        func(arr1)
    if len(arr0) == 1:
        Code.append(arr0)
    else:
        func(arr0)
 
func(arr)
code = {}
for i in range(len(Code)):
    if (code.get(Code[i][0][0], "None") == "None"):
        code.setdefault(Code[i][0][0])
    code[Code[i][0][0]] = Code[i][0][2]
print('Код Шеннона-Фано:')
print(code)
print('Закодированное сообщение:')
for i in range(len(text)):
    text[i] = code[text[i]]
    print(text[i], end = '')

a.close()
