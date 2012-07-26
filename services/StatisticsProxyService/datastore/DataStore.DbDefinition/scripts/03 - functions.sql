

create or replace function config.getconfigurations( p_indicatorId integer, p_geolevel text)
returns SETOF config.configurationview
AS $$
declare
	ret_row record;
BEGIN
	if p_geolevel is not null then
		FOR ret_row in select cv.configuration_id, cv.configuration_geolevel, cv.shapefile_id, 
					cv.shapefile_name, cv.shapefile_path, cv.shapefile_filename, cv.shapefile_level
			from config.configurationview as cv join config.indicator_configuration as ic
			on(cv.configuration_id = ic.configuration_id)
			where ic.indicator_id = p_indicatorId and cv.configuration_geolevel = p_geolevel
		loop
			return next ret_row;
		end loop;
	else	
		FOR ret_row in select cv.configuration_id, cv.configuration_geolevel, cv.shapefile_id, 
					cv.shapefile_name, cv.shapefile_path, cv.shapefile_filename, cv.shapefile_level
			from config.configurationview as cv join config.indicator_configuration as ic
			on(cv.configuration_id = ic.configuration_id)
			where ic.indicator_id = p_indicatorId
		loop
			return next ret_row;
		end loop;
	end if;
	return;
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
-- test
--select * from config.getconfigurations(1, 'NUTS1');
--select * from config.getconfigurations(1, null);


create or replace function config.getShapefileConfigurarionURL( p_indicatorId integer, p_geolevel text)
returns text
AS $$
BEGIN
	return (select cv.shapefile_path || E'\\' || cv.shapefile_filename
	from config.configurationview as cv join config.indicator_configuration as ic
	on(cv.configuration_id = ic.configuration_id)
	where ic.indicator_id = p_indicatorId and cv.configuration_geolevel = p_geolevel);

	
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select config.getShapefileConfigurarionURL(1, 'NUTS1')




create or replace function config.getIndicatorsByProviderId( p_providerId integer, p_page int, p_recordsPerPage int)
returns SETOF config.indicatorview
AS $$
declare 
	v_offset integer;
	ret_row record;
BEGIN

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, 
					provider_url, indicator_id, indicator_sourceid, indicator_name, 
					indicator_nameabbr, indicator_themeid, indicator_subthemeid
				FROM config.indicatorview
				where provider_id = p_providerId
				offset v_offset
				limit p_recordsPerPage
		loop
			RETURN NEXT ret_row;
		end loop;
	end;
	else
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, 
					provider_url, indicator_id, indicator_sourceid, indicator_name, 
					indicator_nameabbr, indicator_themeid, indicator_subthemeid
				FROM config.indicatorview
				where provider_id = p_providerId
		loop
			RETURN NEXT ret_row;
		end loop;
	end if;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';


---------------------------------------------------
--test
--select * from config.getIndicatorsByProviderId(1, 1, 3)





create or replace function config.getIndicatorsBySubThemeId( p_providerId integer, p_themeId int, p_subthemeId int, p_page int, p_recordsPerPage int)
returns SETOF config.indicatorview
AS $$
declare 
	v_offset integer;
	ret_row record;
BEGIN

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, 
					provider_url, indicator_id, indicator_sourceid, indicator_name, 
					indicator_nameabbr, indicator_themeid, indicator_subthemeid
				FROM config.indicatorview
				where provider_id = p_providerId and indicator_themeid = p_themeId and indicator_subthemeid = p_subthemeId
				offset v_offset
				limit p_recordsPerPage
		loop
			RETURN NEXT ret_row;
		end loop;
	end;
	else
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, 
					provider_url, indicator_id, indicator_sourceid, indicator_name, 
					indicator_nameabbr, indicator_theme_id, indicator_subthemeid
				FROM config.indicatorview
				where provider_id = p_providerId and indicator_themeid = p_themeId and indicator_subthemeid = p_subthemeId
		loop
			RETURN NEXT ret_row;
		end loop;
	end if;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';


---------------------------------------------------
--test
--select * from config.getIndicatorsBySubThemeId(1, 1, 1, 1, 1)



create or replace function config.getProviders(p_page int, p_recordsPerPage int)
returns SETOF config.providerview
AS $$
declare 
	v_offset integer;
	ret_row record;
BEGIN

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, provider_url
				FROM config.providerview
				offset v_offset
				limit p_recordsPerPage
		loop
			RETURN NEXT ret_row;
		end loop;
	end;
	else
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, provider_url
				FROM config.providerview
		loop
			RETURN NEXT ret_row;
		end loop;
	end if;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select * from config.getProviders(1, 1)



create or replace function config.getShapefiles(p_shapefilegroupId int, p_page int, p_recordsPerPage int)
returns SETOF config.shapefileview
AS $$
declare 
	v_offset integer;
	ret_row record;
	query text;
BEGIN

	query:= 'SELECT shapefile_id, shapefile_name, shapefile_path, shapefile_filename, 
			shapefile_level, shapefilegroup_id, shapefilegroup_name
		 FROM config.shapefileview';

	if p_shapefilegroupid is not null then
		query:= query || ' where shapefilegroup_id=' || p_shapefilegroupId;
	end if;
	

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		query:= query || ' offset ' || v_offset || ' limit ' || p_recordsPerPage;
	end;
	end if;


	FOR ret_row in EXECUTE query
	loop
		RETURN NEXT ret_row;
	end loop;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';


---------------------------------------------------
--test
--select * from config.getShapefiles(null, null, null)
--select * from config.getShapefiles(1, 1, 1)


create or replace function config.getshapefilegroups(p_page int, p_recordsPerPage int)
returns SETOF config.shapefilegroupview
AS $$
declare 
	v_offset integer;
	ret_row record;
BEGIN

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		FOR ret_row in SELECT shapefilegroup_id, shapefilegroup_name
				FROM config.shapefilegroupview
				offset v_offset
				limit p_recordsPerPage
		loop
			RETURN NEXT ret_row;
		end loop;
	end;
	else
		FOR ret_row in SELECT shapefilegroup_id, shapefilegroup_name
				FROM config.shapefilegroupview
		loop
			RETURN NEXT ret_row;
		end loop;
	end if;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select * from config.getshapefilegroups(1, 1)
--select * from config.getshapefilegroups(null, null)

create or replace function config.insertprovider(p_name text, p_nameAbbr text, p_serviceUrl text, p_url text)
returns int
AS $$
declare 
	last_inserted_id integer;
BEGIN

	INSERT INTO config.provider(name, nameAbbr, serviceURL, URL)
	VALUES(p_name, p_nameAbbr, p_serviceUrl, p_url) returning id into last_inserted_id;
	
	return last_inserted_id;
	
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select config.insertprovider('teste', '1', '2', '3')

create or replace function config.inserttheme(p_name text, p_nameAbbr text, p_providerid int)
returns int
AS $$
declare 
	last_inserted_id integer;
BEGIN

	INSERT INTO config.theme(name, nameAbbr, provider_id)
	VALUES(p_name, p_nameAbbr, p_providerid) returning id into last_inserted_id;
	
	return last_inserted_id;
	
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select config.inserttheme('teste', '1', 33);

create or replace function config.insertsubtheme(p_name text, p_nameAbbr text, p_themeid int, p_providerid int)
returns int
AS $$
declare 
	last_inserted_id integer;
BEGIN

	INSERT INTO config.subtheme(name, nameAbbr, theme_id, provider_id)
	VALUES(p_name, p_nameAbbr, p_themeid, p_providerid) returning id into last_inserted_id;
	
	return last_inserted_id;
	
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select config.insertsubtheme('1', '2', 1, 33);

create or replace function config.insertindicator(p_name text, p_nameAbbr text, p_sourceid text, p_themeid int, p_subthemeid int, p_providerid int)
returns int
AS $$
declare 
	last_inserted_id integer;
BEGIN

	INSERT INTO config.indicator(name, nameAbbr, sourceid, theme_id, subtheme_id, provider_id)
	VALUES(p_name, p_nameAbbr, p_sourceid, p_themeid, p_subthemeid, p_providerid) returning id into last_inserted_id;
	
	return last_inserted_id;
	
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select config.insertindicator('1', '2', '1', 1, 1, 33);


create or replace function config.addconfiguration(p_geolevel text, p_shapefileid int, p_indicatorid int)
returns int
AS $$
declare 

	last_configid integer;
	last_indicator_configid integer;
	
BEGIN

	if (exists (select 1 from config.configuration where geolevel = p_geolevel and shapefile_id = p_shapefileid)) then
	begin
		select id into last_configid from config.configuration where geolevel = p_geolevel and shapefile_id = p_shapefileid;
	end;
	else
		insert into config.configuration(geolevel, shapefile_id) values(p_geolevel, p_shapefileid) returning id into last_configid;
	end if;

	INSERT INTO config.indicator_configuration(indicator_id, configuration_id)
	VALUES(p_indicatorid, last_configid);

	return last_configid;
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select config.addconfiguration('NUTS1', 4, 4)