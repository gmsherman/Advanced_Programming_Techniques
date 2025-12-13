# Server Applicaion for Student Admissions 

# Library modules imported 
import socket
import pyodbc
import random
import json

# User-defined function MSSQL
def MSSQL_Server():
    try:
        server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        server_socket.bind(('127.0.0.1', 1433))

        print("\n========== STUDENTS ADMISSION SERVER | DUBLIN BUSINESS SCHOOL(DBS) ==========")
        print("\n===== Admissions Server preparing for incoming client connections =====")
        
        server_socket.listen()
        print("\n===== Admissions Server is now listening for incoming client connection =====")
        server_socket.settimeout(120)

        while True:
            client_socket, addr = server_socket.accept()
            print(f"Client is connected from {addr}")
            
            # Receive data from Client
            application_info = client_socket.recv(1024).decode()
            registration_number = SQL_connection(application_info)

            # Send the application number back to the client upon storing in the database
            client_socket.sendall(registration_number.encode())
            client_socket.close()

    except Exception as e:
        print(f"Server timed out. Reconnect again: {e}")
    finally:
        server_socket.close()

def SQL_connection(application_info):
    try:
        # Parses incoming JSON data
        data = json.loads(application_info)
        
        name = data['name']
        address = data['address']
        educational_qualification = data['education']
        course = data['course']
        start_year = data['start_year']
        start_month = data['start_month']
        
        # Generates a unique registration number to send to client
        unique_registration_number = f"{random.randint(10000000, 99999999)}"

        # Utilizing Windows Authentication to establish the SQL Server connection to the database ADMDBS
        conn = pyodbc.connect("DRIVER={ODBC Driver 17 for SQL Server};SERVER=MFDP\\SQLEXPRESS03;DATABASE=ADMDBS;Trusted_Connection=yes")
        cursor = conn.cursor()

        # Inserts Applicant information into the database
        query = """
        INSERT INTO StudentApplications (Name, Address, EducationalQualification, Course, StartYear, StartMonth, UniqueRegistrationNumber)
        VALUES (?, ?, ?, ?, ?, ?, ?)
        """
        cursor.execute(query, (name, address, educational_qualification, course, int(start_year), int(start_month), unique_registration_number))
        conn.commit()

        return unique_registration_number  # Returns the generated application number

    except json.JSONDecodeError as e:
        print(f"Error parsing JSON data: {e}")
        return "Error: Invalid JSON format"
    except pyodbc.Error as e:
        print(f"Database connection failed: {e}")
        return "Error: Database connection failed"
    except Exception as e:
        print(f"Error inserting data: {e}")
        return "Error: An unexpected error occurred"
    finally:
        try:
            cursor.close()
            conn.close()
        except:
            pass  

if __name__ == "__main__":
    MSSQL_Server()
