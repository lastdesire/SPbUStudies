#Задание 4.3.1, 4.4
#Для сообщения “abcbbbbbacabbacddacdbbaccbbadadaddd abcccccbacabbacbbaddbdaccbbddadadcc  bcabbcdabacbbacbbddcbbaccbbdbdadaac<EOF>”, приняв за алфавит {a,b,c,d,<space>,<EOF>}
#1) Построить код Шеннона для двухбуквенных блоков символов.
#2) Закодировать сообщение.
import math
#Считываем текст, создав словарь symbols, где ключи -- символы, а значения -- их количество в тексте.
a = open("input.txt", 'r')
text = []
symbol = a.read(1)
while (symbol):
    text.append(symbol)
    symbol = a.read(1)
#text.append("<EOF>")

symbols = {}
q = set(text)
for i in q:
    for j in q:
        symbols.setdefault(i + j, 0)
for i in range(0, len(text), 2):
    symbols[text[i] + text[i + 1]] += 1

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
    if saved_sorted_symbols[key] == 0:
        l = 0
        s = "Символ в тексте не встречается, не кодируем"
    else:
        l = math.ceil(-math.log2(saved_sorted_symbols[key]))
        s = ""
    for i in range(0, l):
        s += sorted_symbols[key][i + 2]
    saved_sorted_symbols[key] = s
print("2. Коды по алгоритму Шеннона:")
for key in saved_sorted_symbols:
    print(key, saved_sorted_symbols[key])


#Кодируем текст.
new_text = []
for i in range (0, len(text), 2):
    symbol = text[i] + text[i + 1]
    new_text.append(saved_sorted_symbols[symbol])
print("Закодированный текст:")
for i in range(len(new_text)):
    print(new_text[i], end = '')

a.close()


