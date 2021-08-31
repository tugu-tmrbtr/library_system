USE LibraryDB;

CREATE TABLE loginTable(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
username VARCHAR(150) NOT NULL,
pass VARCHAR(150) NOT NULL
)

INSERT INTO loginTable (username, pass) VALUES ('admin', '1234');
INSERT INTO loginTable (username, pass) VALUES ('root', '1234');

SELECT * FROM loginTable;


CREATE TABLE NewBook(
bid INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
bName VARCHAR(250) NOT NULL,
bAuthor VARCHAR(250) NOT NULL,
bPubl VARCHAR(250) NOT NULL,
bDate VARCHAR(250) NOT NULL,
bPrice BIGINT NOT NULL,
bQuan BIGINT NOT NULL
)

SELECT * FROM NewBook;


CREATE TABLE NewStudent(
stuid INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
sName VARCHAR(250) NOT NULL,
enroll VARCHAR(250) NOT NULL,
dep VARCHAR(250) NOT NULL,
sCode VARCHAR(250) NOT NULL,
contact BIGINT NOT NULL,
sEmail VARCHAR(250) NOT NULL
)



SELECT * FROM NewStudent;


CREATE TABLE IRBook(
id INT NOT NULL  IDENTITY(1,1) PRIMARY KEY,
std_enroll VARCHAR(250) NOT NULL,
std_name VARCHAR(250) NOT NULL,
std_dep VARCHAR(250) NOT NULL,
std_code VARCHAR(250) NOT NULL,
std_contact BIGINT NOT NULL,
std_email VARCHAR(250) NOT NULL,
book_name VARCHAR(250) NOT NULL,
book_issue_date VARCHAR(250) NOT NULL,
book_return_date VARCHAR(250) NULL,
)


INSERT INTO IRBook (std_enroll, std_name, std_dep, std_code, std_email, std_contact, book_name, book_issue_date) VALUES ('PU-1010', 'Tuguldur','IT','B190920012','ttuguldur0426@gmail.com', 95518464, 'C', 'Friday, May 21, 2021');

SELECT * FROM IRBook;