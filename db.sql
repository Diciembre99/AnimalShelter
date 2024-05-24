-- This script was generated by the ERD tool in pgAdmin 4.
-- Please log an issue at https://github.com/pgadmin-org/pgadmin4/issues/new/choose if you find any bugs, including reproduction steps.
BEGIN;


CREATE TABLE IF NOT EXISTS public."Shelter"
(
    id_shelter integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(20) COLLATE pg_catalog."default" NOT NULL,
    direccion text COLLATE pg_catalog."default",
    cif character varying(11) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Shelter_pkey" PRIMARY KEY (id_shelter)
);

CREATE TABLE IF NOT EXISTS public."__EFMigrationsHistory"
(
    "MigrationId" character varying(150) COLLATE pg_catalog."default" NOT NULL,
    "ProductVersion" character varying(32) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE IF NOT EXISTS public.adoption
(
    id_user integer NOT NULL,
    id_adoption integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    pet_id integer NOT NULL,
    date_adoption time without time zone NOT NULL,
    CONSTRAINT adoption_pkey PRIMARY KEY (id_user)
);

CREATE TABLE IF NOT EXISTS public.appointment
(
    id_appoitment integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(20) COLLATE pg_catalog."default" NOT NULL,
    date time without time zone,
    description text COLLATE pg_catalog."default",
    id_pet integer NOT NULL,
    veterinary character varying COLLATE pg_catalog."default",
    CONSTRAINT appointment_pkey PRIMARY KEY (id_appoitment)
);

CREATE TABLE IF NOT EXISTS public.donation
(
    id_donation integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    type_donation character varying(20) COLLATE pg_catalog."default",
    quantity money,
    donor character varying(20) COLLATE pg_catalog."default",
    date_donation date NOT NULL,
    id_shelter integer NOT NULL,
    CONSTRAINT donation_pkey PRIMARY KEY (id_donation)
);

CREATE TABLE IF NOT EXISTS public.items
(
    id_item integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(20) COLLATE pg_catalog."default",
    stock integer,
    type_item character varying(20) COLLATE pg_catalog."default",
    animal_type character varying(20) COLLATE pg_catalog."default",
    id_shelter integer,
    status character(1) COLLATE pg_catalog."default",
    CONSTRAINT items_pkey PRIMARY KEY (id_item)
);

CREATE TABLE IF NOT EXISTS public.permissions
(
    id_permission integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    id_user integer,
    id_rol integer,
    CONSTRAINT permissions_pkey PRIMARY KEY (id_permission)
);

CREATE TABLE IF NOT EXISTS public.pet
(
    id_pet integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(20) COLLATE pg_catalog."default",
    race character varying(20) COLLATE pg_catalog."default",
    age text COLLATE pg_catalog."default",
    genre character(1) COLLATE pg_catalog."default",
    date_entry text COLLATE pg_catalog."default",
    medical_history text COLLATE pg_catalog."default",
    status character(1) COLLATE pg_catalog."default",
    id_shelter integer,
    "Description" text COLLATE pg_catalog."default",
    CONSTRAINT pet_pkey PRIMARY KEY (id_pet)
);

CREATE TABLE IF NOT EXISTS public.rol
(
    id_rol integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(20) COLLATE pg_catalog."default" NOT NULL,
    description text COLLATE pg_catalog."default",
    type character(1) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT rol_pkey PRIMARY KEY (id_rol)
);

CREATE TABLE IF NOT EXISTS public.user_cataloge
(
    id_cataloge integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(20) COLLATE pg_catalog."default" NOT NULL,
    type character(1) COLLATE pg_catalog."default" NOT NULL,
    description character varying(20) COLLATE pg_catalog."default",
    CONSTRAINT user_cataloge_pkey PRIMARY KEY (id_cataloge)
);

CREATE TABLE IF NOT EXISTS public.users
(
    id_user integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(20) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    dni character varying(11) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying,
    telephone character varying(20) COLLATE pg_catalog."default",
    username character varying(20) COLLATE pg_catalog."default",
    password character varying(20) COLLATE pg_catalog."default",
    id_cataloge integer NOT NULL DEFAULT 0,
    id_shelter integer NOT NULL DEFAULT 0,
    CONSTRAINT users_pkey PRIMARY KEY (id_user)
);

ALTER TABLE IF EXISTS public.adoption
    ADD CONSTRAINT adoption_id_user_fkey FOREIGN KEY (id_user)
    REFERENCES public.users (id_user) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS adoption_pkey
    ON public.adoption(id_user);


ALTER TABLE IF EXISTS public.adoption
    ADD CONSTRAINT pet_id FOREIGN KEY (pet_id)
    REFERENCES public.pet (id_pet) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;
CREATE INDEX IF NOT EXISTS "IX_adoption_pet_id"
    ON public.adoption(pet_id);


ALTER TABLE IF EXISTS public.appointment
    ADD CONSTRAINT appointment_id_pet_fkey FOREIGN KEY (id_pet)
    REFERENCES public.pet (id_pet) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_appointment_id_pet"
    ON public.appointment(id_pet);


ALTER TABLE IF EXISTS public.donation
    ADD CONSTRAINT donation_id_shelter_fkey FOREIGN KEY (id_shelter)
    REFERENCES public."Shelter" (id_shelter) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_donation_id_shelter"
    ON public.donation(id_shelter);


ALTER TABLE IF EXISTS public.items
    ADD CONSTRAINT items_id_shelter_fkey FOREIGN KEY (id_shelter)
    REFERENCES public."Shelter" (id_shelter) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_items_id_shelter"
    ON public.items(id_shelter);


ALTER TABLE IF EXISTS public.permissions
    ADD CONSTRAINT permissions_id_rol_fkey FOREIGN KEY (id_rol)
    REFERENCES public.rol (id_rol) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_permissions_id_rol"
    ON public.permissions(id_rol);


ALTER TABLE IF EXISTS public.permissions
    ADD CONSTRAINT permissions_id_user_fkey FOREIGN KEY (id_user)
    REFERENCES public.users (id_user) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_permissions_id_user"
    ON public.permissions(id_user);


ALTER TABLE IF EXISTS public.pet
    ADD CONSTRAINT pet_id_shelter_fkey FOREIGN KEY (id_shelter)
    REFERENCES public."Shelter" (id_shelter) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_pet_id_shelter"
    ON public.pet(id_shelter);


ALTER TABLE IF EXISTS public.users
    ADD CONSTRAINT id_cataloge FOREIGN KEY (id_cataloge)
    REFERENCES public.user_cataloge (id_cataloge) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_users_id_cataloge"
    ON public.users(id_cataloge);


ALTER TABLE IF EXISTS public.users
    ADD CONSTRAINT users_id_shelter_fkey FOREIGN KEY (id_shelter)
    REFERENCES public."Shelter" (id_shelter) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_users_id_shelter"
    ON public.users(id_shelter);

END;