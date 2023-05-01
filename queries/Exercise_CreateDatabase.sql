-- Database: Exercise

-- DROP DATABASE IF EXISTS "Exercise";

CREATE DATABASE "Exercise"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

GRANT TEMPORARY, CONNECT ON DATABASE "Exercise" TO PUBLIC;

GRANT ALL ON DATABASE "Exercise" TO postgres;