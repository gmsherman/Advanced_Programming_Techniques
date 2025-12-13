
# Scraping Hotel websites for price data

# Required libraries for making http requests to fetch webpages, parsing html to extract data, and handling csv operations
import requests
from bs4 import BeautifulSoup
import pandas as pd
import csv

# URLs of the hotels' websites to be scraped
urls = ["https://dublinsamplehotel1.tiiny.site/","https://dublinsamplehotel2.tiiny.site/"]

# Utilizing the data structure List to hold data of the rooms
roomsData = []

# User-defined function to scrape hotel data
def hotel_data(urls):
    response = requests.get(urls)
    soup = BeautifulSoup(response.content, 'html.parser')

    # Find room listings using the class name 'room-card'
    rooms = soup.find_all('div', class_='room-card')  
    
    for room in rooms:
        roomName = room.find('div', class_='room-type').text.strip()
        
        # Get all price items for this room
        price_items = room.find_all('div', class_='price-item')
        
        for price_item in price_items:
            date = price_item.find('span', class_='date').text.strip()
            price = price_item.find('span', class_='price').text.strip()
            
            # Appending hotel data
            roomsData.append({
                'Hotel': urls,
                'Room Name': roomName,
                'Date': date,
                'Price': price
            })

# Scrape data from both hotels
for url in urls:
    hotel_data(url)

if roomsData:
# Save the hotel data to a CSV file named hotel_data
    csv_file = 'hotel_data.csv'
    fieldnames = ['Hotel', 'Room Name', 'Date', 'Price']

    with open(csv_file, 'w+', newline='') as csvfile:
        dict_writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
        dict_writer.writeheader()
        dict_writer.writerows(roomsData)
    
    print(f"\nHotel data has been successfully saved to {csv_file}")
    print(f"Total hotel data entries scraped: {len(roomsData)}")

# Retrieve and display all data from the CSV file
    print("\n" + "="*80)
    print("----- RETRIEVING ALL DATA FROM THE CSV FILE -----")
    print("="*80 + "\n")
    
    # CSV file opening for writing
    with open(csv_file, 'r', newline='') as csvfile:
        csv_reader = csv.DictReader(csvfile)
        for row in csv_reader:
            print(f"Hotel: {row['Hotel']}, Room: {row['Room Name']}, Date: {row['Date']}, Price: {row['Price']}")
    
    print("\n" + "="*80)
    print("END OF PRINTED DATA")
    print("="*80)
else:
    print("Hotel data not available.")