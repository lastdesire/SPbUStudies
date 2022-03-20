#Задание 4.2.3 и 4.3
#Для сообщения “abcbbbbbacabbacddacdbbaccbbadadaddd abcccccbacabbacbbaddbdaccbbddadadcc bcabbcdabacbbacbbddcbbaccbbdbdadaac<EOF>”, приняв за алфавит {a,b,c,d,<space>,<EOF>}
#2) Построить код Хаффмана для отдельных символов.
#3) Закодировать сообщение.
#При запуске программы введите "main()" в консоль.
#Источник: http://e-postulat.ru/index.php/Postulat/article/viewFile/617/638
import heapq
from collections import Counter
from collections import namedtuple

class Node(namedtuple("Node", ["left", "right"])):
    def walk(self, code, acc):
        self.left.walk(code, acc + "0")
        self.right.walk(code, acc + "1")

class Leaf(namedtuple("Leaf", ["char"])):
    def walk(self, code, acc):
        code[self.char] = acc or "0"

def huffman_encode(s):
    h = []
    for ch, freq in Counter(s).items():
        h.append((freq, len(h), Leaf(ch)))
    heapq.heapify(h)
    count = len(h)
    while len(h) > 1:
        freq1, _count1, left = heapq.heappop(h)
        freq2, _count2, right = heapq.heappop(h)
        heapq.heappush(h, (freq1 + freq2, count, Node(left, right)))
        count += 1
    code = {}
    if h:
        [(_freq, _count, root)] = h
        root.walk(code, "")
    return code

def main():
    a = open("input.txt", 'r')
    text = []
    symbol = a.read(1)
    while (symbol):
        text.append(symbol)
        symbol = a.read(1)
    text.append("<EOF>") #Добавляем <EOF>. 
    code = huffman_encode(text)
    encoded = "".join(code[ch] for ch in text)
    for ch in sorted(code):
        print("{}: {}".format(ch, code[ch]))
    print("Закодированное сообщение:", encoded)
              
    a.close()    
