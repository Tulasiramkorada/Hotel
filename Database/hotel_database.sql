--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: guest; Type: TABLE; Schema: public; Owner: youth_admin
--

CREATE TABLE public.guest (
    guest_id bigint NOT NULL,
    guest_name character varying(50) NOT NULL,
    guest_details character varying(50) NOT NULL
);


ALTER TABLE public.guest OWNER TO youth_admin;

--
-- Name: guest_guest_id_seq; Type: SEQUENCE; Schema: public; Owner: youth_admin
--

CREATE SEQUENCE public.guest_guest_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.guest_guest_id_seq OWNER TO youth_admin;

--
-- Name: guest_guest_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: youth_admin
--

ALTER SEQUENCE public.guest_guest_id_seq OWNED BY public.guest.guest_id;


--
-- Name: rooms; Type: TABLE; Schema: public; Owner: youth_admin
--

CREATE TABLE public.rooms (
    room_id bigint NOT NULL,
    room_type bigint NOT NULL,
    room_no bigint NOT NULL,
    staff_id bigint NOT NULL
);


ALTER TABLE public.rooms OWNER TO youth_admin;

--
-- Name: rooms_room_id_seq; Type: SEQUENCE; Schema: public; Owner: youth_admin
--

CREATE SEQUENCE public.rooms_room_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.rooms_room_id_seq OWNER TO youth_admin;

--
-- Name: rooms_room_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: youth_admin
--

ALTER SEQUENCE public.rooms_room_id_seq OWNED BY public.rooms.room_id;


--
-- Name: roomservicestaff; Type: TABLE; Schema: public; Owner: youth_admin
--

CREATE TABLE public.roomservicestaff (
    staff_id bigint NOT NULL,
    staff_name character varying(50) NOT NULL,
    staff_address character varying(50) NOT NULL,
    contact_number bigint NOT NULL
);


ALTER TABLE public.roomservicestaff OWNER TO youth_admin;

--
-- Name: roomservicestaff_staff_id_seq; Type: SEQUENCE; Schema: public; Owner: youth_admin
--

CREATE SEQUENCE public.roomservicestaff_staff_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.roomservicestaff_staff_id_seq OWNER TO youth_admin;

--
-- Name: roomservicestaff_staff_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: youth_admin
--

ALTER SEQUENCE public.roomservicestaff_staff_id_seq OWNED BY public.roomservicestaff.staff_id;


--
-- Name: stayschedule; Type: TABLE; Schema: public; Owner: youth_admin
--

CREATE TABLE public.stayschedule (
    stayschedule_id bigint NOT NULL,
    room_id bigint NOT NULL,
    guest_id bigint NOT NULL,
    check_in timestamp(5) without time zone NOT NULL,
    check_out timestamp(5) with time zone NOT NULL
);


ALTER TABLE public.stayschedule OWNER TO youth_admin;

--
-- Name: stayschedule_stayschedule_id_seq; Type: SEQUENCE; Schema: public; Owner: youth_admin
--

CREATE SEQUENCE public.stayschedule_stayschedule_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.stayschedule_stayschedule_id_seq OWNER TO youth_admin;

--
-- Name: stayschedule_stayschedule_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: youth_admin
--

ALTER SEQUENCE public.stayschedule_stayschedule_id_seq OWNED BY public.stayschedule.stayschedule_id;


--
-- Name: guest guest_id; Type: DEFAULT; Schema: public; Owner: youth_admin
--

ALTER TABLE ONLY public.guest ALTER COLUMN guest_id SET DEFAULT nextval('public.guest_guest_id_seq'::regclass);


--
-- Name: rooms room_id; Type: DEFAULT; Schema: public; Owner: youth_admin
--

ALTER TABLE ONLY public.rooms ALTER COLUMN room_id SET DEFAULT nextval('public.rooms_room_id_seq'::regclass);


--
-- Name: roomservicestaff staff_id; Type: DEFAULT; Schema: public; Owner: youth_admin
--

ALTER TABLE ONLY public.roomservicestaff ALTER COLUMN staff_id SET DEFAULT nextval('public.roomservicestaff_staff_id_seq'::regclass);


--
-- Name: stayschedule stayschedule_id; Type: DEFAULT; Schema: public; Owner: youth_admin
--

ALTER TABLE ONLY public.stayschedule ALTER COLUMN stayschedule_id SET DEFAULT nextval('public.stayschedule_stayschedule_id_seq'::regclass);


--
-- Data for Name: guest; Type: TABLE DATA; Schema: public; Owner: youth_admin
--

COPY public.guest (guest_id, guest_name, guest_details) FROM stdin;
1	ajay	vijayawada
2	kiran	eluru
3	seetha	japan
0	strings	stringsss
\.


--
-- Data for Name: rooms; Type: TABLE DATA; Schema: public; Owner: youth_admin
--

COPY public.rooms (room_id, room_type, room_no, staff_id) FROM stdin;
2	2	1002	1022
3	3	1003	1023
0	1	0	1
1	1	1001	1021
\.


--
-- Data for Name: roomservicestaff; Type: TABLE DATA; Schema: public; Owner: youth_admin
--

COPY public.roomservicestaff (staff_id, staff_name, staff_address, contact_number) FROM stdin;
2	ajay	dubai	1234567890
3	saritha	bihar	7654321098
1	pavan	tirupathi	9876543211
\.


--
-- Data for Name: stayschedule; Type: TABLE DATA; Schema: public; Owner: youth_admin
--

COPY public.stayschedule (stayschedule_id, room_id, guest_id, check_in, check_out) FROM stdin;
1	1	1	2022-03-12 00:00:00	2022-04-06 00:00:00+05:30
2	2	2	2021-02-09 00:00:00	2022-11-06 00:00:00+05:30
\.


--
-- Name: guest_guest_id_seq; Type: SEQUENCE SET; Schema: public; Owner: youth_admin
--

SELECT pg_catalog.setval('public.guest_guest_id_seq', 3, true);


--
-- Name: rooms_room_id_seq; Type: SEQUENCE SET; Schema: public; Owner: youth_admin
--

SELECT pg_catalog.setval('public.rooms_room_id_seq', 3, true);


--
-- Name: roomservicestaff_staff_id_seq; Type: SEQUENCE SET; Schema: public; Owner: youth_admin
--

SELECT pg_catalog.setval('public.roomservicestaff_staff_id_seq', 3, true);


--
-- Name: stayschedule_stayschedule_id_seq; Type: SEQUENCE SET; Schema: public; Owner: youth_admin
--

SELECT pg_catalog.setval('public.stayschedule_stayschedule_id_seq', 2, true);


--
-- Name: guest guest_pkey; Type: CONSTRAINT; Schema: public; Owner: youth_admin
--

ALTER TABLE ONLY public.guest
    ADD CONSTRAINT guest_pkey PRIMARY KEY (guest_id);


--
-- Name: rooms rooms_pkey; Type: CONSTRAINT; Schema: public; Owner: youth_admin
--

ALTER TABLE ONLY public.rooms
    ADD CONSTRAINT rooms_pkey PRIMARY KEY (room_id);


--
-- Name: roomservicestaff roomservicestaff_pkey; Type: CONSTRAINT; Schema: public; Owner: youth_admin
--

ALTER TABLE ONLY public.roomservicestaff
    ADD CONSTRAINT roomservicestaff_pkey PRIMARY KEY (staff_id);


--
-- Name: stayschedule stayschedule_pkey; Type: CONSTRAINT; Schema: public; Owner: youth_admin
--

ALTER TABLE ONLY public.stayschedule
    ADD CONSTRAINT stayschedule_pkey PRIMARY KEY (stayschedule_id);


--
-- PostgreSQL database dump complete
--

