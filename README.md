# ENDPOINTS

### 1. Listar Empleados

```bash
http://localhost:5054/api/Empleado
```

### 2. Listar Vigilantes

```bash
http://localhost:5054/api/Empleado/Vigilantes
```



### 3. Listar Telefono Vigilante

```bash
http://localhost:5054/api/Empleado/TelefonoVigilante
```



### 4. Listar Clientes Bucaramanga



```bash
http://localhost:5054/api/Cliente/ClienteBucaramanga
```

### 5. Listar Empleados Giron, Piedecuesta

```bash
http://localhost:5054/api/Empleado/EmpleadoPiedecuestaYGiron
```



### 6. Listar Clientes con 5 años antiguedad

```bash
http://localhost:5054/api/Cliente/Antiguedad5annos
```

### 7. Listar Contratos activos, se muestra #contrato, nombre cliente, empleado que registro el contrato

```bash
http://localhost:5054/api/Contrato/Activos
```





# JWT

## Login

```bash
curl -X 'GET' \
  'http://localhost:5054/login?username=iker' \
  -H 'accept: */*'
```

## Register

```bash
curl -X 'GET' \
  'http://localhost:5054/user' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer CfDJ8Osq-5LFhwdOn8fLskjXk7mJ0pBYTctUFLjX0ZDfYSev-pSoLIOaqXk7cgqFW-62ow5v2VFjvyMHmop76sCYIvIpAfi_jkRViH-5zLl95pa7Ph64t0eyroNYAnDMuhiTZp9JHk2zhxNnwSKZJ4lrrmE_jIQikvq6Rjp1lAbOjtlEoqC_RaDznCd3UoI-rcOMVXhRuN2RHfZLa4ZlU3fy506ACyrlKJqY_6EDEHpRhtgFo7yJ4xoeTjiIvInaaKXHgCfxvQOr6CUyKxgbQLEgH6Y'
```

#### Response

"Welcome iker!"


