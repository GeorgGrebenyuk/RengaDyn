# RengaDyn
Пакет нодов (функциональных методов) для среды визуального программирования Dynamo Core для работы в среде САПР Renga

***Старый репозиторий с таким же именем от начала января 2022г. был удален; это его новая реализация.***

# О пакете
Настоящй репозиторий содержит исходный код для набора нодов (функциональных методов) на языке C#, написанных под Renga API -- для параллельной работы с процессом Renga и элементами модели. Имеющиеся ноды позволяют получать геометрию, свойства объетов, управлять выборкой объектов. Возможен импорт своих свойств и назначением значений параметров. Имеющиеся функциональные возможности полностью вторят доступным в Renga API. Набор бдет расширяться по мере появления новых методов API

# Справка и документация
Настоящий пакет содержит встроенное описание методов. Примеры скриптов (готовых файлов их наборов нодов в формате \*.dyn см. в папке DynamoScripts настоящего репозитория. Поверхностно, действия с пакетом освещены в процессе расширенного курса "Renga API - Программирование" (выйдет к середине июля 2022 года). 

# Использование
Писалось и тестировалось под Dynamo Core 2.12
## Для пользователя
Наиболее удобный вариант - загрузка последней версии через встроенный в Dynamo менеджер пакетов (Package manager). Распространяемая коллекция нодов называется "RengaDyn".
### Вставить гифку
Альтернативный вариант (при отсутствии Интернета либо при блокировке сервисов Dynamo - это установка пакета вручную, то есть загрузка версии отсюда и размещение в системном каталоге Dynamo:
1. Заходим в раздел [Releases](https://github.com/GeorgGrebenyuk/RengaDynamo/releases) и выбираем последнюю версию пакета и архив формата ZIP с наименованием ```RengaDyn_***.zip```
2. Переходим к каталогу ```%APPDATA%\Dynamo\Dynamo Core\2.12\packages```, где ```2.12``` - ваша установленная версия DynamoCore и распаковываем в данную папку (папку packages) содержимое архива (появится папка ```RengaDyn``` с набором файлов). ДЛя обновления пакета вручную потребуется её удалить и заменить новой версией.

### Вставить гифку
## Для разработчика/для отладки
Склонировать себе данный репозиторий, собрать (для сборки нужно RengaSDK - получить [тут](https://rengabim.com/sdk/). В среде Dynamo выбрать ```Файл - Импорт библиотеки``` и далее указать файл RengaDynMain.dll. В настройках проекта выбрать ```Debug - Start external program``` и ввести абсолютный файловый путь до приложения ```DynamoSandbox.exe``` используемой версии DynamoCore.

