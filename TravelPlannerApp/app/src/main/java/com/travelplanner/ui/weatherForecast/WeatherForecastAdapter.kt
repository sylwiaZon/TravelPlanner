package com.travelplanner.ui.weatherForecast

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.Tour
import com.travelplanner.models.WeatherForecast
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class WeatherForecastAdapter() : RecyclerView.Adapter<WeatherForecastAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
    }
    private var weatherList: List<WeatherForecast> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_tour, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return weatherList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val formatter = DateTimeFormatter.ofLocalizedDate(FormatStyle.LONG)
        val date = holderView.findViewById<TextView>(R.id.weather_date)
        date.text = weatherList[position].date.format(formatter)
        val description = holderView.findViewById<TextView>(R.id.weather_description)
        description.text = weatherList[position].weather[0].weatherDescription
        val degrees = holderView.findViewById<TextView>(R.id.weather_degrees)
        degrees.text = weatherList[position].temperature.toString() + " \u2109"
        val icon = holderView.findViewById<ImageView>(R.id.weather_icon)
        Glide
                .with(holderView.context)
                .load(weatherList[position]?.weather[0]?.weatherIcon)
                .into(icon)
    }

    public fun setData(data: List<WeatherForecast>) {
        weatherList = data
        notifyDataSetChanged()
    }
}