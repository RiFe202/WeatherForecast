<!DOCTYPE html>
<html>
<head>
    <title>Weather Forecast</title>
</head>
<body>
    <h1>Weather Forecast</h1>
    <div id="forecast"></div>

    <script>
        fetch('/api/weather/forecast')
            .then(response => response.json())
            .then(data => {
                const forecastDiv = document.getElementById('forecast');
                forecastDiv.innerHTML = JSON.stringify(data, null, 2);
            })
            .catch(error => console.error('Error fetching forecast:', error));
    </script>
</body>
</html>