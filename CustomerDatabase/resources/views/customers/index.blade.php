<!doctype html>
<html lang="{{ app()->getLocale() }}">
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">

<title>Customers</title>
<link href="{{ URL::asset('/css/styles.css') }}" rel="Stylesheet"
	type="text/css" />
</head>
<body>
	<div id="content">
		<h1>Customer Database</h1>
		<table>
			<tr>
				<th>First Name</th>
				<th>Last Name</th>
				<th>Email Address</th>
			</tr>
			@foreach($customers as $cust)
			<tr>
				<td>{{ $cust->first_name }}</td>
				<td>{{ $cust->last_name }}</td>
				<td>{{ $cust->email_address }}</td>
			</tr>
			@endforeach
		</table>
		<p>
			<a href="{{url('customers/create')}}">Create new customer</a>
		</p>
	</div>
</body>
</html>
