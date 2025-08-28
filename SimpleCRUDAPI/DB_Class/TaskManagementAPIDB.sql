/*
SQLyog Community v13.1.9 (64 bit)
MySQL - 8.3.0 : Database - taskmanagementdb
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`taskmanagementdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `taskmanagementdb`;

/*Table structure for table `tasks` */

DROP TABLE IF EXISTS `tasks`;

CREATE TABLE `tasks` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) NOT NULL,
  `Description` text,
  `IsCompleted` tinyint(1) NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tasks` */

insert  into `tasks`(`Id`,`Title`,`Description`,`IsCompleted`,`CreatedAt`,`UpdatedAt`) values 
(1,'Buy groceries','Milk, Eggs, Bread',0,'2025-08-28 12:33:43','2025-08-28 12:33:43'),
(2,'Finish project','string',1,'2025-08-28 12:33:43','2025-08-28 16:46:09'),
(3,'Read book','Read 30 pages of novel',1,'2025-08-28 12:33:43','2025-08-28 12:33:43');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
