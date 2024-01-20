
CREATE TABLE `phoneoper` (
  `opet_id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `opet_name` varchar(45) DEFAULT NULL,
  `opet_logo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`opet_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


INSERT INTO `sgcmdb`.`phoneoper` (`opet_name`) VALUES ('Movistar');
INSERT INTO `sgcmdb`.`phoneoper` (`opet_name`) VALUES ('Claro');
INSERT INTO `sgcmdb`.`phoneoper` (`opet_name`) VALUES ('Bitel');
INSERT INTO `sgcmdb`.`phoneoper` (`opet_name`) VALUES ('Entel');

SELECT * FROM phoneoper