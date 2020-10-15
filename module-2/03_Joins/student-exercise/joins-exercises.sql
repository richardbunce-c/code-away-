-- The following queries utilize the "dvdstore" database.

-- 1. All of the films that Nick Stallone has appeared in
-- (30 rows)
Select f.title
From Actor a
Join film_actor fa on a.actor_id=fa.actor_id
Join film f on fa.film_id=f.film_id
Where a.first_name= 'NICK' and a.last_name='STALLONE'



-- 2. All of the films that Rita Reynolds has appeared in
-- (20 rows)
Select f.title
From Actor a
Join film_actor fa on a.actor_id=fa.actor_id
Join film f on fa.film_id=f.film_id
Where a.first_name= 'RITA' and a.last_name='Reynolds'

-- 3. All of the films that Judy Dean or River Dean have appeared in
-- (46 rows)
Select f.title
From Actor a
Join film_actor fa on a.actor_id=fa.actor_id
Join film f on fa.film_id=f.film_id
Where a.first_name= 'JUDY'or a.first_name='RIVER' and a.last_name='DEAN' 


-- 4. All of the the ‘Documentary’ films
-- (68 rows)
Select f.title
From film f
Join film_category fc ON f.film_id = fc.film_id
Join category c ON fc.category_id = c.category_id
Where c.name = 'Documentary'


-- 5. All of the ‘Comedy’ films
-- (58 rows)
Select f.title
From film f
Join film_category fc on f.film_id=fc.film_id
Join category c on fc.category_id=c.category_id
Where c.name='Comedy'


-- 6. All of the ‘Children’ films that are rated ‘G’
-- (10 rows)
Select f.title
From film f
Join film_category fc on f.film_id=fc.film_id
Join category c on fc.category_id=c.category_id
Where c.name='Children' and f.rating='G'



-- 7. All of the ‘Family’ films that are rated ‘G’ and are less than 2 hours in length
-- (3 rows)
Select f.title
From film f
Join film_category fc on f.film_id=fc.film_id
Join category c on fc.category_id=c.category_id
Where c.name='Family' and f.rating='G'and f.length<120



-- 8. All of the films featuring actor Matthew Leigh that are rated ‘G’
-- (9 rows)
Select f.title
From film f
Join film_actor fa ON fa.film_id = f.film_id
Join actor a ON a.actor_id = fa.actor_id
Where f.rating = 'G' AND a.first_name = 'MATTHEW' AND a.last_name = 'LEIGH'



-- 9. All of the ‘Sci-Fi’ films released in 2006
-- (61 rows)
Select f.title
From film f
Join film_category fc on f.film_id=fc.film_id
Join category c on fc.category_id=c.category_id
Where c.name='Sci-Fi' and f.release_year='2006'



-- 10. All of the ‘Action’ films starring Nick Stallone
-- (2 rows)
Select f.title
From film f
Join film_actor fa on fa.film_id=f.film_id
Join actor a on a.actor_id=fa.actor_id
Join film_category fc on f.film_id=fc.film_id
Join category c on c.category_id=fc.category_id
Where a.first_name='NICK' and a.last_name='STALLONE' and c.name='Action'



-- 11. The address of all stores, including street address, city, district, and country
-- (2 rows)
Select address, address2, city, district, country 
From store
Join address on address.address_id = store.address_id
Join city on city.city_id = address.city_id
Join country on country.country_id = city.country_id



-- 12. A list of all stores by ID, the store’s street address, and the name of the store’s manager
-- (2 rows)
Select s.store_id, address, st.first_name, st.last_name
From store s
Join address a on a.address_id=s.address_id
Join staff st on st.staff_id=s.manager_staff_id


-- 13. The first and last name of the top ten customers ranked by number of rentals 
-- (#1 should be “ELEANOR HUNT” with 46 rentals, #10 should have 39 rentals)
Select Top 10 c.first_name, c.last_name, count(r.rental_id)
From customer c
Join rental r on r.customer_id=c.customer_id
Group by c.first_name, c.last_name
Order by count(r.rental_id) desc


-- 14. The first and last name of the top ten customers ranked by dollars spent 
-- (#1 should be “KARL SEAL” with 221.55 spent, #10 should be “ANA BRADLEY” with 174.66 spent)
Select Top 10 c.first_name, c.last_name, sum(p.amount) as total_payment
From customer c
Join payment p on p.customer_id=c.customer_id
Group by c.first_name, c.last_name
Order by total_payment desc


-- 15. The store ID, street address, total number of rentals, total amount of sales (i.e. payments), and average sale of each store.
-- (NOTE: Keep in mind that an employee may work at multiple stores.)
-- (Store 1 has 7928 total rentals and Store 2 has 8121 total rentals)
Select s.store_id, a.address, count(r.rental_id) as 'total number of rentals', sum(p.amount) as 'total sales', sum(p.amount)/count(r.rental_id) as 'average sales'
From store s
Join address a on a.address_id=s.address_id
Join inventory i on s.store_id=i.store_id
Join rental r on r.inventory_id=i.inventory_id
Join payment p on r.rental_id=p.rental_id
Group by s.store_id, a.address
Order by s.store_id


-- 16. The top ten film titles by number of rentals
-- (#1 should be “BUCKET BROTHERHOOD” with 34 rentals and #10 should have 31 rentals)
Select f.title, count(r.rental_id)
From rental r
Join inventory i on r.inventory_id=i.inventory_id
Join film f on i.film_id=f.film_id
Group by f.title
Order by count(r.rental_id) desc



-- 17. The top five film categories by number of rentals 
-- (#1 should be “Sports” with 1179 rentals and #5 should be “Family” with 1096 rentals)
Select c.name, count(r.rental_id) as 'number of rentals'
From category c
Join film_category fc on c.category_id=fc.category_id
Join film f on fc.film_id=f.film_id
Join inventory i on f.film_id=i.film_id
Join rental r on i.inventory_id=r.inventory_id
Group by c.name
Order by 'number of rentals' desc



-- 18. The top five Action film titles by number of rentals 
-- (#1 should have 30 rentals and #5 should have 28 rentals)
Select f.title, count(r.rental_id) as 'number of rentals'
From category c
Join film_category fc ON c.category_id = fc.category_id
Join film f ON f.film_id = fc.film_id
Join inventory i ON f.film_id = i.film_id
Join rental r ON i.inventory_id = r.inventory_id
Where c.name = 'Action'
Group by f.title
Order by count(r.rental_id) desc



-- 19. The top 10 actors ranked by number of rentals of films starring that actor 
-- (#1 should be “GINA DEGENERES” with 753 rentals and #10 should be “SEAN GUINESS” with 599 rentals)
Select Top 10 a.actor_id, a.first_name, a.last_name, count(r.rental_id) as 'number of rentals'
From actor a
Join film_actor fa on a.actor_id = fa.actor_id
Join film f on f.film_id = fa.film_id
Join inventory i on f.film_id = i.film_id
Join rental r on i.inventory_id = r.inventory_id
Group by a.actor_id,a.last_name, a.first_name
Order by count(r.rental_id) desc




-- 20. The top 5 “Comedy” actors ranked by number of rentals of films in the “Comedy” category starring that actor 
-- (#1 should have 87 rentals and #5 should have 72 rentals)
Select Top 5 a.first_name, a.last_name, count(r.rental_id)
From actor a
Join film_actor fa ON a.actor_id = fa.actor_id
Join film f ON fa.film_id = f.film_id
Join film_category fc ON f.film_id = fc.film_id
Join category c ON fc.category_id = c.category_id 
Join inventory i ON f.film_id = i.film_id
Join rental r ON i.inventory_id = r.inventory_id
Where c.name = 'Comedy'
Group by a.first_name, a.last_name
Order by count(r.rental_id) desc


