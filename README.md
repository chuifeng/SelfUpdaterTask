# Задание

Цель: Разработать программу, которая будет обновлять сама себя.

Язык: C#

Требования: Корректная работа в ОС Windows XP – Windows 8.1. 
____________________________
Основные функциональные возможности:
1.	Отображение текущей версии*
2.	Обновление программы
________________________________
Структура каталогов:

•	Y:\new

•	Y:\new\test.exe

•	Y:\test.exe
____________________________
При запуске программы должно появиться окно с информацией о версии файла и кнопкой «Обновить».

При нажатии кнопки «Обновить» необходимо заменить файл «Y:\test.exe» файлом «Y:\new\test.exe». После успешной замены файла необходимо запустить программу заново.

Программы «Y:\new\test.exe» и «Y:\test.exe» идентичны друг другу за исключением версий файлов. Версии файлов «Y:\test.exe» и «Y:\new\test.exe» должны быть разными.

При запуске программы с параметром «ShowVersion» должно появляться сообщение с текстом «Версия программы текущая_версия_программы» и кнопкой «ОК». После нажатия на кнопку «ОК» программа должна быть закрыта.
