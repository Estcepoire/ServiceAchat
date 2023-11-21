create database achat;
\c achat

create table departement(
    id SERIAL PRIMARY KEY,
    nom VARCHAR(50)
);

insert into departement values (default,'securite');

create table produit(
    id SERIAL PRIMARY KEY,
    nom VARCHAR(50),
    unite VARCHAR(50)
);


insert into produit values (default,'cache bouche','boite');
insert into produit values (default,'stylo','unite');

create table unite(
    id SERIAL PRIMARY KEY,
    nom VARCHAR(50)
);

insert into unite values(default,'piece');
insert into unite values(default,'boite');

create table besoins(
    id SERIAL PRIMARY KEY,
    id_departement int REFERENCES departement(id),
    it_produit int REFERENCES produit(id),
    quantite DOUBLE PRECISION,
    etat VARCHAR(50) default '0',
    dates date default now()
);

create view all_besoins as (SELECT b.id, p.nom as nom_produit, d.nom as nom_departement, b.unite, b.etat FROM besoins b JOIN produit p on b.id_produit = p.id JOIN departement d ON d.id_departement = d.id);

create table besoins_validation(
    id SERIAL PRIMARY KEY,
    id_departement int,
    it_produit int,
    quantite DOUBLE PRECISION,
    unite VARCHAR(50),
    etat VARCHAR(50),
    FOREIGN KEY(id_departement) REFERENCES departement(id),
    FOREIGN KEY(id_produit) REFERENCES produit(id),
);

create view all_besoins_valider as (SELECT b.id, p.nom as nom_produit, d.nom as nom_departement, b.unite, b.etat FROM besoins_validation b JOIN produit p on b.id_produit = p.id JOIN departement d ON d.id_departement = d.id);

create table fournisseur(
    id SERIAL PRIMARY KEY,
    nom VARCHAR(50),
    adresse VARCHAR(50),
    contact VARCHAR(50),
    mail VARCHAR(50)
);

insert into fournisseur values (default,'shop1', 'lot123 Ivandry','0341234567','shop1@gmail.com');
insert into fournisseur values (default,'shop2', 'lot345 Analakely','0334568234','shop2@gmail.com');

create table fournisseur_produit(
    id SERIAL PRIMARY KEY,
    id_fournisseur int,
    id_produit int,
    prix DOUBLE PRECISION,
    id_unite int,
    date DATE,
    FOREIGN KEY(id_fournisseur) REFERENCES fournisseur(id),
    FOREIGN KEY(id_produit) REFERENCES produit(id),
    FOREIGN KEY(id_unite) REFERENCES unite(id),
);

insert into fournisseur_produit values(default,1,1,300,1,'2023-11-15');
insert into fournisseur_produit values(default,1,1,3000,2,'2023-11-15');
insert into fournisseur_produit values(default,1,2,800,1,'2023-11-15');
insert into fournisseur_produit values(default,1,2,20000,2,'2023-11-15');
insert into fournisseur_produit values(default,2,2,700,1,'2023-11-15');
insert into fournisseur_produit values(default,2,2,18000,'2023-11-15');

create view all_fournisseur_produit as (SELECT fp.id,f.nom as nom_fournisseur,p.nom as nom_produit, fp.prix, u.nom, fp.date FROM fournisseur_produit fp JOIN fournisseur f on fp.id_fournisseur = f.id JOIN produit p on fp.id_produit = p.id JOIN unite u ON fp.id_unite = u.id);


-- create table proforma(
--     id SERIAL PRIMARY KEY,
--     id_produit int,
--     id_fournisseur int,
--     quantite DOUBLE PRECISION,
--     id_unite int,
--     prix_total DOUBLE PRECISION,
--     FOREIGN KEY(id_produit) REFERENCES produit(id),
--     FOREIGN KEY(id_fournisseur) REFERENCES fournisseur(id),
--     FOREIGN KEY(id_unite) REFERENCES unite(id)
-- );

create table proforma(
    id SERIAL PRIMARY KEY,
    id_produit int,
    id_fournisseur int,
    prix_total DOUBLE PRECISION,
    date DATE,
    quantite DOUBLE PRECISION,
    FOREIGN KEY(id_produit) REFERENCES produit(id),
    FOREIGN KEY(id_fournisseur) REFERENCES fournisseur(id)
);

create view v_proforma as (SELECT p.id, pr.nom as nom_produit, f.nom as nom_fournisseur, p.prix_total, p.date, p.quantite FROM proforma p JOIN produit pr ON p.id_produit = pr.id JOIN fournisseur f ON p.id_fournisseur = f.id);


















