# HackathonTest
## Завдання
Візьміть курс USD / BTC з загальнодоступних даних від 3-х криптовалютних обмінників (наприклад, Bittrex, Yobit, Kraken)
Визначте, чи буде вигідно купити криптовалюту в одному обміннику, вилучити і продати її іншому, включаючи комісії.
Створіть графік курсу біткойна, використовуючи курси обміну для покупки
Ви можете вибрати будь-які фреймворки/технології, пов'язані з JS :)
Зробіть короткий огляд, як побудувати проект.
## Проект складається з таких частин 

* ### [WebAPI](https://github.com/ThinkAndTravel/HackathonTest/tree/master/BitCoin/BitCoin/BitCoin)
Яке збирає інформацію кожну хвилину про курс USD/BTC з таких обмінників 

[Bitstamp](https://www.bitstamp.net) 

[Bitfinex](https://www.bitfinex.com/)

[Kraken](https://www.kraken.com)

Яким чином проводиться збір інформації можна проглянути в [GetRate.cs](https://github.com/ThinkAndTravel/HackathonTest/blob/master/BitCoin/CurrenciesRate/GetRate.cs)

Також WebAPI передає інформацію, для побудови графіків в Мобільний додаток через[HomeControler.cs](https://github.com/ThinkAndTravel/HackathonTest/blob/master/BitCoin/BitCoin/BitCoin/Controllers/HomeController.cs)
WebAPI опубліковано на [Azure](http://bitcoinweb20180123125040.azurewebsites.net)
* ### БД (MongoDB)
Де зберігаються дані зібрані WebAPI. Ми використовуємо [mLab](https://mlab.com)
* ### Мобільний додаток (Xamarin)
В Додатку будуємо графік купівлі BTC за останні 24 години (ми беремо найменше значення в цей момент часу з 3 обмінників)![photo1](https://github.com/ThinkAndTravel/HackathonTest/blob/master/photo_2018-01-23_22-15-18.jpg)
і графік який показує чи вігідно і який буде з цього прибуток буде купити BTC в одному обміннику і продати в іншому (враховуючи комісії) в даний момент часу. 
![photo2](https://github.com/ThinkAndTravel/HackathonTest/blob/master/photo_2018-01-23_22-15-11.jpg)
![photo3](https://github.com/ThinkAndTravel/HackathonTest/blob/master/photo_2018-01-23_22-15-23.jpg)
