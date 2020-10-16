-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
Insert into actor values ('Hampton', 'Avenue')
Insert into actor values ('Lisa', 'Byway')
Select * from actor 
Order by actor_id desc

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
Insert into film (title, description, release_year, language_id,length)
			values('Euclidean PI', 'The epic story of Euclid as a pizza delivery boy in ancient Greece', 2008, 1,198)

Select * from film order by film_id desc


-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.
Insert into film_actor values (201,1001)
Insert into film_actor values(202,1001)

Select * from film_actor order by film_id desc 


-- 4. Add Mathmagical to the category table.
insert into category values ('Mathmagical')

Select * from category


-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"
Select * from film where title in('Euclidean PI','EGG IGBY','KARATE MOON', 'RANDOM GO','YOUNG LANGUAGE')

Insert into film_category values (274,17)
Insert into film_category values (494,17)
Insert into film_category values (714,17)
Insert into film_category values (996,17)
Insert into film_category values (1001,17)

Select * from film_category order by category_id desc


-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)
Select * from film where film_id in (274,494,714,996,1001)

Update film set rating = 'G' 
Where film_id in(274, 494, 714, 996, 1001)

-- 7. Add a copy of "Euclidean PI" to all the stores.
Select * From store

Insert into inventory values (274,1)
Insert into inventory values (274,2)
Insert into inventory values (494,1)
Insert into inventory values (494,2)
Insert into inventory values (714,1)
Insert into inventory values (714,2)
Insert into inventory values (996,1)
Insert into inventory values (996,2)
Insert into inventory values (1001,1)
Insert into inventory values (1001,2)

Select * from inventory where film_id in (274,494,714,996,1001)

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
Delete film where film_id=1001

-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>
It failed because "film" has foreign keys from other tables.  This acts as a constraint that prevents deletion of the record.

-- 9. Delete Mathmagical from the category table.
Select * from category where category_id=17

Delete category where category_id=17

-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>
It failed because the primary key from category is referenced in another table "film_category"

-- 10. Delete all links to Mathmagical in the film_category tale.
Select * from film_category
Select *from film_category where category_id=17

Delete film_category where category_id=17

-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>
It did succeed because "Mathmagical" is associated with "film_category" as a foreign key

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
Delete category where category_id=17

Select * from category 

Delete film where film_id=1001

Select * from film where film_id=1001

-- (Did either deletes succeed? Why?)
-- <YOUR ANSWER HERE>
I was able to delete the "Mathmagical" category because there was not anything else in the database that was referencing it.
I could not delete the "Euclidean PI" because it is still being referenced by the "film_actor" table


-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.
I would have to delete all the occurences of "film_id 1001" from other tables.  The "film_actor" still references the "Euclidean PI film _Id"