-- Execute script as root
CREATE USER 'CartoLoggerAdmin'@'localhost' IDENTIFIED BY 'admin';
CREATE DATABASE CartoLoggerDev;
GRANT ALL PRIVILEGES ON CartoLoggerDev.* TO 'CartoLoggerAdmin'@'localhost';

