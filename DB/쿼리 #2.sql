-- 10. 아이템 테이블 생성
CREATE TABLE items (
   item_id INT AUTO_INCREMENT PRIMARY KEY,
   name VARCHAR(100) NOT NULL,
   description TEXT,
   value INT DEFAULT 0
);

-- 11. 아이템 데이터 삽입
INSERT INTO items (name, description, value) VALUES
('검', '기본 무기', 10),
('방패', '기본 방어구', 15),
('물약', '체력을 회복', 5);
