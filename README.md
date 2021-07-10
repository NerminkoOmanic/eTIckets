# eTIckets

Seminarski rad za predmet Razvoj softvera 2

Docker details:  
-> API localhost:65010  
-> pristup sql serveru preko SSMS-a , port 1401


Login details:  
-> admin moze pristupiti samo WinForms  
-> korisnik moze pristupiti samo Mobile  

Administrator  
username : admin  
password : Reset1  

User  
username: user  
password: Reset1  

username: user2  
password: Reset1  

U seeding sam dodao sve ulaznice da prodaje user2, tako da za kupovinu treba koristit user, a i ostavio sam jednog korisnika da nema jos dodanih ulaznica da mozete isprobati i funkcionalnost dodavanja bankovnog računa, te nemogucnost predaje zahtjeva za prodaju dok se ne doda bankovni račun.

Online payment details:  
Online payment service je zamisljen kao zasebna baza, da bi to ponasanje imitirao 3 tabele unutar baze su povezane međusoobno ali ne i sa ostatkom baze, posto nijedan payment service nebi imali dostupno unutar nase aplikacije zelio sam simulirati slicno ponasanje


Da bi korisnik mogao prodavati ulaznice mora imati registriran validan broj bankovnog racuna  
Bank accounts:  
1. bank account number(id) : 111111111111  
2. bank account number(id) : 222222222222  

Credit card:  

Credit card 1  
Card number (id) : 1111111111111111  
ControlNumber : 111  
Owner : test  
Valid : 03/22  
Account : 111111111111  

Credit card 2  
Card number (id) : 2222222222222222  
ControlNumber : 222  
Owner : test  
Valid : 03/22  
Account : 222222222222  
