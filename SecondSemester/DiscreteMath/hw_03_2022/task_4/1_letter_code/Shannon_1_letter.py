#Задание 4.1, 4.2.1, 4.4
#Для сообщения “abcbbbbbacabbacddacdbbaccbbadadaddd abcccccbacabbacbbaddbdaccbbddadadcc  bcabbcdabacbbacbbddcbbaccbbdbdadaac<EOF>”, приняв за алфавит {a,b,c,d,<space>,<EOF>}
#1) Определить энтропию.
#2) Построить код Шеннона для отдельных символов.
#3) Закодировать сообщение.

import math
#Считываем текст, создав словарь symbols, где ключи -- символы, а значения -- их количество в тексте.
a = open("input.txt", 'r')
text = []
symbols = {}
symbol = a.read(1)
while (symbol):
    text.append(symbol)
    if (symbols.get(symbol, "None") == "None"):
        symbols.setdefault(symbol, 1)
    else:
        symbols[symbol] += 1
    symbol = a.read(1)
symbols.setdefault("<EOF>", 1) #Добавляем <EOF>.
text.append("<EOF>")

#Алгоритм Шеннона:
#Пусть нам даны наборы A и P, тогда для нахождения кодовых слов необходимо:
#1.Отсортировать элементы алфавита по не возрастанию вероятности встречи символа.
#2.Элементу ax поставить в соответствие число bx = ∑ i ∈ [1 , x − 1] pi, при этом b1 = 0.
#3.Представить каждое число bx в виде двоичной дроби.
#4.В качестве кодового слова для ax использовать первые Lx = ⌈−logpx⌉ коэффициентов представления bx. (⌈z⌉ — наименьшее целое число, не меньшее z)

#Выставляем значениям в словаре вероятности.
text_len = len(text)
for key in symbols:
    symbols[key] /= text_len

#Считаем энтропию и печатаем ее.
h = 0
for key in symbols:
    h += symbols[key] * math.log2(symbols[key])
h = -h
print("1: Энтропия", h)

#Сортируем в обратном порядке.
sorted_symbols = {}
sorted_keys = sorted(symbols, key = symbols.get, reverse = True)

for i in sorted_keys:
    sorted_symbols[i] = symbols[i]
print("Символы и вероятность их встретить в тексте:", sorted_symbols)  
#2. Храним в массиве sorted_symbols сопоставляемые числа, а массив saved_sorted_symbols используем в #4.
saved_sorted_symbols = {}
for key in sorted_symbols:
    saved_sorted_symbols[key] = sorted_symbols[key]
values = []
values.append(0)
for key in sorted_symbols:
    values.append(sorted_symbols[key])
counter = 0
for key in sorted_symbols:
    sorted_symbols[key] = 0
    for i in range(0, counter + 1):
        sorted_symbols[key] += values[i]
    counter += 1
        

#3. https://ru.stackoverflow.com/questions/738774
from math import copysign, fabs, floor, isfinite, modf

def float_to_bin_fixed(f):
    if not isfinite(f):
        return repr(f)  # inf nan

    sign = '-' * (copysign(1.0, f) < 0)
    frac, fint = modf(fabs(f))  # split on fractional, integer parts
    n, d = frac.as_integer_ratio()  # frac = numerator / denominator
    assert d & (d - 1) == 0  # power of two
    return f'{sign}{floor(fint):b}.{n:0{d.bit_length()-1}b}'

for key in sorted_symbols:
    sorted_symbols[key] = str(float_to_bin_fixed(sorted_symbols[key])) + "0000000000"

#4.
for key in saved_sorted_symbols:
    l = math.ceil(-math.log2(saved_sorted_symbols[key]))
    s = ""
    for i in range(0, l):
        s += sorted_symbols[key][i + 2]
    saved_sorted_symbols[key] = s
print("2. Коды по алгоритму Шеннона:", saved_sorted_symbols)


#Кодируем текст.
for i in range (len(text)):
    text[i] = saved_sorted_symbols[text[i]]

b = open("output_4_2_1.txt", 'w')
for i in range(len(text)):
    b.write(text[i])

a.close()
b.close()


