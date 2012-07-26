
drop schema if exists config cascade;


CREATE SCHEMA config;


CREATE TABLE config.shapefilegroup
(
  id 		serial primary key,
  name 		text
);


CREATE TABLE config.shapefile
(
  id 		serial primary key,
  name 		text,
  path 		text not null,
  filename 	text not null,
  level 	integer not null,
  
  shapefilegroup_id integer references config.shapefilegroup(id)
);

CREATE TABLE config.provider
(
  id 		serial primary key,
  name 		text not null,
  nameabbr 	text not null,
  serviceURL 	text not null,
  url 		text not null
);

CREATE TABLE config.theme
(
  id 		serial,
  provider_id 	integer,
  name 		text not null,
  nameabbr 	text,

  CONSTRAINT theme_pk PRIMARY KEY (id, provider_id),
  CONSTRAINT theme_provider_id_fk FOREIGN KEY (provider_id) REFERENCES config.provider (id)  
);

CREATE TABLE config.subtheme
(
  id 		serial,
  theme_id 	integer,
  provider_id 	integer,
  name 		text not null,
  nameabbr 	text,

  CONSTRAINT subtheme_pk PRIMARY KEY (id, theme_id, provider_id),
  CONSTRAINT subtheme_theme_id_fk FOREIGN KEY (theme_id, provider_id) REFERENCES config.theme (id, provider_id)  
);

CREATE TABLE config.indicator
(
  id 		serial primary key,
  provider_id 	integer not null,
  sourceid 	text not null,
  name 		text not null,
  nameabbr 	text not null,
  theme_id 	integer,
  subtheme_id 	integer,
  
  CONSTRAINT indicator_provider_id_fk FOREIGN KEY (provider_id) REFERENCES config.provider (id),
  CONSTRAINT indicator_subtheme_id_fk FOREIGN KEY (provider_id, theme_id, subtheme_id) REFERENCES config.subtheme (provider_id, theme_id, id)  
);

CREATE TABLE config.configuration
(
  id 		serial primary key,
  geolevel 	text not null,
  shapefile_id 	integer references config.shapefile(id) not null
);


CREATE TABLE config.indicator_configuration
(
  indicator_id 		integer,
  configuration_id 	integer,
  
  CONSTRAINT indicatorconfiguration_pk PRIMARY KEY (indicator_id, configuration_id),
  CONSTRAINT indicatorconfiguration_indicator_id_fk FOREIGN KEY (indicator_id) REFERENCES config.indicator (id),
  CONSTRAINT indicatorconfiguration_configuration_id_fk FOREIGN KEY (configuration_id) REFERENCES config.configuration (id)
);


----------------------------------------------------------------------------------------
------------------------------------- Views --------------------------------------------
----------------------------------------------------------------------------------------


create or replace view config.shapefilegroupview
AS
 select id as shapefilegroup_id, name as shapefilegroup_name
 from config.shapefilegroup;


create or replace view config.shapefileview
AS
 select s.id as shapefile_id, s.name as shapefile_name, s.path as shapefile_path, s.filename as shapefile_filename, 
	s.level as shapefile_level, sg.id as shapefilegroup_id, sg.name as shapefilegroup_name
 from config.shapefile as s join config.shapefilegroup as sg
 on(s.shapefilegroup_id = sg.id);


create or replace view config.configurationview
AS
 select c.id as configuration_id, c.geoLevel as configuration_geolevel, s.id as shapefile_id, 
	s.name as shapefile_name, s.path as shapefile_path, s.filename as shapefile_filename, s.level as shapefile_level
 from config.configuration as c join config.shapefile as s
 on(c.shapefile_id = s.id);


create or replace view config.indicatorview
AS
 select p.id as provider_id, p.name as provider_name, p.nameAbbr as provider_nameAbbr, 
	p.serviceURL as provider_serviceURL, p.url as provider_url,
	i.id as indicator_id, i.sourceid as indicator_sourceid, i.name as indicator_name, 
	i.nameabbr as indicator_nameabbr, i.theme_id as indicator_themeid, i.subtheme_id as indicator_subthemeid
 from config.indicator as i join config.provider as p
 on(i.provider_id = p.id);


create or replace view config.providerview
AS
 SELECT id as provider_id, name as provider_name, nameabbr as provider_nameabbr, 
	serviceurl as provider_serviceurl, url as provider_url
  FROM config.provider;



create or replace view config.themeview
AS
 SELECT id as theme_id, provider_id, "name" as theme_name, nameabbr as theme_nameabbr
  FROM config.theme;

create or replace view config.subthemeview
AS
 SELECT id as subtheme_id, theme_id, provider_id, "name" subtheme_name, nameabbr as subtheme_nameabbr
  FROM config.subtheme;

  
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
---------------------------------------- VALUES -----------------------------------------
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------
------------------------------------- shapes  ----------------------------------------
--------------------------------------------------------------------------------------

INSERT INTO config.shapefilegroup(name) VALUES('concelhos distritos e freguesias de portugal');
INSERT INTO config.shapefile(name, path, filename, level, shapefilegroup_id) 
	VALUES(
		'distritos', 	
		E'D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\sapo\\GIS\\Distritos', 
		'distritos.shp', 
		1, 
		1
	);
INSERT INTO config.shapefile(name, path, filename, level, shapefilegroup_id) 
	VALUES(
		'concelhos', 	
		E'D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\sapo\\GIS\\Concelhos', 
		'concelhos.shp', 
		2, 
		1
	);
INSERT INTO config.shapefile(name, path, filename, level, shapefilegroup_id) 
	VALUES(
		'freguesias', 	
		E'D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\sapo\\GIS\\Freguesias', 
		'freguesias.shp', 
		3, 
		1
	);


INSERT INTO config.shapefilegroup(name) VALUES('Nomenclaturas de unidades territorias (NUTS) 2002.');
INSERT INTO config.shapefile(name, path, filename, level, shapefilegroup_id) 
	VALUES(
		'NUTS1', 	
		E'D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\sapo\\GIS\\NUTS1', 
		'nuts1.shp', 
		1, 
		2
	);
INSERT INTO config.shapefile(name, path, filename, level, shapefilegroup_id) 
	VALUES(
		'NUTS2', 	
		E'D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\sapo\\GIS\\NUTS2', 
		'nuts2.shp', 
		2, 
		2
	);
INSERT INTO config.shapefile(name, path, filename, level, shapefilegroup_id) 
	VALUES(
		'NUTS3', 	
		E'D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\sapo\\GIS\\NUTS3', 
		'nuts3.shp', 
		3, 
		2
	);
