gametest-- 1. 데이터 베이스 생성
CREATE DATABASE `GameTest` /*!40100 COLLATE 'utf8mb4_0900_cj' */;

-- 2. 테이블 생성
CREATE TABLE `players`(
   `player_id` INT NOT NULL AUTO_INCREMENT,
	`username` VARCHAR(50) NULL DEFAULT NULL,
	`email` VARCHAR(50) NULL DEFAULT NULL,
	`password_hash` VARCHAR(255) NULL DEFAULT NULL,
	`create_at` TIMESTAMP NULL DEFAULT NULL,
	`last_login` TIMESTAMP NULL DEFAULT NULL, 
	PRIMARY KEY (`player_id`),
	UNIQUE INDEX `username` (`username`),
	UNIQUE INDEX `email` (`email`)
);

-- 3. 플레이어 데이터 삽입
INSERT INTO players(username, email, password_hash) VALUES ('hero123', 'hero123@gmail.com' , 'hashed_password');