from bs4 import BeautifulSoup as soup
from urllib.request import urlopen as uReq  # Web client


# URl откуда скрейпим.
page_url = "http://www.banki.ru/products/deposits/?source=submenu_deposits"
# открываем подключение и загружаем html страницу 
uClient = uReq(page_url)
# парсим html в структуру soup
page_soup = soup(uClient.read(), "html.parser")
uClient.close()
# находим каждый продукт в контейнере
containers = page_soup.findAll("div", {"class": "lac5283b9"})
# создадим файл где будут храниться данные
out_filename = "deposit.csv"
headers = "bank,title,rate,limit,sum,sum2 \n"
f = open(out_filename, "w", encoding='utf-16')
f.write(headers)
# ищем все совпадения по классам
for container in containers:
    brand = container.div.select("a")
    bank = brand[0].img["alt"].title()
    title = container.findAll("div",{"class":"l3848bca4 text-size-6"})[0].text
    rate = container.findAll("span",{"class":"text-size-3 text-weight-bolder"})[0].text
    limit = container.findAll("div",{"class":"text-size-4"})[0].text
    sum = container.findAll("span",{"class":"text-size-4"})[0].text.strip().replace("₽", "")
    sum =  sum.replace(" ", "")
    title =  title.replace('"', "")
    if("от" in sum): 
      sum =  sum.replace("от", "")
      sum2 = "10000000"
    if("—" in sum): 
      sum2 = sum.rsplit("—")[1]
      sum =  sum.split("—")[0]
    # wзаписываем наборы данных в файл
    f.write(bank + "; " + title + "; " + rate + "; " + limit + "; "  + sum + "; " + sum2 + "; " + "\n")
f.close()  

page_url ="https://www.banki.ru/products/credits/?amount=0&applicationReviewPeriod3DaysMax=0&borrowerType=0&currency=RUB&order=desc&period=0&purpose=0&sort=popular&top_hundred_place=0&withoutCollateral=0&withoutIncomeRequirement=0&withoutInsurance=0"
uClient = uReq(page_url)
page_soup = soup(uClient.read(), "html.parser")
uClient.close()
out_filename = "credit.csv"
headers = "bank,title,rate,sum \n"
containers = page_soup.findAll("div", {"class": "lac5283b9"})
f = open(out_filename, "w", encoding='utf-32')
f.write(headers)
for container in containers:
    brand = container.div.select("a")
    bank = brand[0].img["title"].title()
    title = container.findAll("div",{"class":"l3848bca4"})[0].text
    rate = container.findAll("span",{"class":"text-size-3 text-weight-bolder"})[0].text
    sum = container.findAll("span",{"class":"text-size-4 text-nowrap"})[0].text.strip().replace(" ", "")
    sum =  sum.replace("₽", "")
    sum =  sum.replace("до", "")
    sum =  sum.replace("от", "")
    sum =  sum.replace(" ", "")
    print(sum)
    f.write(bank + "; " + title + "; " + rate + "; " + sum + "; " + "\n")
f.close()  