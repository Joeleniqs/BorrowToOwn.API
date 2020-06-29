CREATE TRIGGER "product_search_vector_update" BEFORE INSERT OR UPDATE
ON "Products" FOR EACH ROW EXECUTE PROCEDURE
tsvector_update_trigger("SearchVector", 'pg_catalog.english', "Name", "Description", "Model");

UPDATE "Products" SET "Name" = "Name", "Description" = "Description", "Model" = "Model";

