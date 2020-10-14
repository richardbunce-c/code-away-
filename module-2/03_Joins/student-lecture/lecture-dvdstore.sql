-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
Select customer_id
From payment
Where payment_id=16666



-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table
Select c.first_name, c.last_name
From payment p
Join customer c on c.customer_id=p.customer_id
Where payment_id=16666


-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:
Select p.*,c.first_name, c.last_name
From payment p
Join customer c on c.customer_id=p.customer_id
Where payment_id=16666


-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.
Select p.*,c.first_name, c.last_name, r.return_date
From payment p
Join customer c on c.customer_id=p.customer_id
Join rental r on r.rental_id=p.rental_id
Where payment_id=16666


-- What did they rent? Film id can be gotten through inventory.
Select p.*,c.first_name, c.last_name, r.return_date, f.title
From payment p
Join customer c on c.customer_id=p.customer_id
Join rental r on r.rental_id=p.rental_id
Join inventory i on r.inventory_id=i.inventory_id
Join film f on i.film_id=f.film_id
Where payment_id=16666


-- What if we wanted to know who acted in that film?
Select p.*,c.first_name, c.last_name, r.return_date, f.title, a.first_name + '' + a.last_name as actor
From payment p
Join customer c on c.customer_id=p.customer_id
Join rental r on r.rental_id=p.rental_id
Join inventory i on r.inventory_id=i.inventory_id
Join film f on i.film_id=f.film_id
Join film_actor fa on f.film_id=fa.film_id
Join actor a on a.actor_id=fa.actor_id
Where payment_id=16666


-- What if we wanted a list of all the films and their categories ordered by film title
Select title, name
From film f
Join film_category fc on f.film_id=fc.film_id
Join category c on fc.category_id=c.category_id
Order by title




-- Show all the 'Comedy' films ordered by film title
Select title, name
From film f
Join film_category fc on f.film_id=fc.film_id
Join category c on fc.category_id=c.category_id
Where c.name='comedy'
Order by title


-- Finally, let's count the number of films under each category
Select name, count(*)
From category c
Join film_category fc on fc.category_id=c.category_id
Join film f on fc.film_id=f.film_id
Group by name



-- (There aren't any great examples of left joins in the "dvdstore" database, so go back to the "world" queries)

-- *********** UNION *************

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates

-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
