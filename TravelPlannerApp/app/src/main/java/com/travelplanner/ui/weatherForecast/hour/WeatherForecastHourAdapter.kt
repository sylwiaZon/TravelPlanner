package com.travelplanner.ui.weatherForecast.hour

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.WeatherForecast
import java.time.format.DateTimeFormatter

class WeatherForecastHourAdapter() : RecyclerView.Adapter<WeatherForecastHourAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
    }
    private var weatherList: List<WeatherForecast> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_hour_weather_forecast, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return weatherList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val formatter = DateTimeFormatter.ofPattern("EEE, d MMM yyyy HH:mm")
        val date = holderView.findViewById<TextView>(R.id.weather_date)
        date.text = weatherList[position].date.format(formatter)
        val description = holderView.findViewById<TextView>(R.id.weather_description)
        description.text = weatherList[position].weather[0].weatherDescription
        val degrees = holderView.findViewById<TextView>(R.id.weather_degrees)
        degrees.text = weatherList[position].temperature.toString() + " \u2103"
        val icon = holderView.findViewById<ImageView>(R.id.weather_icon)
        Glide
            .with(holderView.context)
            .load("http://" + weatherList[position]?.weather[0]?.weatherIcon)
            .into(icon)
    }

    public fun setData(data: List<WeatherForecast>) {
        weatherList = data
        notifyDataSetChanged()
    }
}