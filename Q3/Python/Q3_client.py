# Client Program for Students Admission 

# Library modules imported 
import socket
import json

# Acquiring details from Applicant(s) for possible Admissions at DBS, using my user-defined function StudentApplications
def StudentApplications():
    # Setup of a connection to the server using IPv4 and TCP
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    
    # Utilizing exception handling to describe error(s)
    try:
        client_socket.connect(('localhost', 1433))  

        # Gather applicant inputs 
        application_data = {
            'name': input("\nEnter your Full Name: "),
            'address': input("Enter your Address: "),
            'education': input("Enter your Educational Qualifications: "),
            'course': input("Enter the Course you wish to enroll in (MSc in Cyber Security | MSc in Information Systems & Computing | MSc in Data Analytics): "),
            'start_year': int(input("Enter your intended start year (YYYY): ")),
            'start_month': int(input("Enter your intended start month (1-12): "))
        }

        # Convert the application data to JSON string
        json_data = json.dumps(application_data)

        # Send the application information over the socket to the server
        client_socket.sendall(json_data.encode())

        # Receive the application number from the server
        registration_number = client_socket.recv(1024).decode()

        print(f'Your unique DBS Application number is: {registration_number}')

    except Exception as e:
        print(f"An error has occurred: {e}")

    finally:
        client_socket.close()

if __name__ == "__main__":
    StudentApplications()
